# 项目快速安装使用

### 安装项目模板

##### 进入CMD直接运行命令，会出现如下图红色框的项目模板

```
dotnet new -i sqlsugar.template
```
![image-20211111095349813](https://user-images.githubusercontent.com/28613121/141225881-33fdad24-c6e1-416e-a91a-8fa86e7cc842.png)

##### 查看安装的模板在哪里？也在CMD中直接运行命令，如下图：

```
dotnet new --list
```
![image-20211111095749281](https://user-images.githubusercontent.com/28613121/141225950-5d137f35-586e-4517-ac76-e2076e5045e4.png)

以上我们的项目模板就安装好了，现在我们来使用模板

### 创建项目模板

用CMD进入你的工作目录，如：D:\test

执行命令：

```
dotnet new sqlsugartemplate -n YXY.Member
```

sqlsugartemplate：是模板的名称

YXY.Member：是你想定义的项目名称

![image-20211111100430541](https://user-images.githubusercontent.com/28613121/141225993-a0a4952a-f9cc-4b6a-826a-c836217a0c39.png)

![image-20211111100356658](https://user-images.githubusercontent.com/28613121/141226015-90ea9d1d-65f3-4f79-aa99-6ea77740fbcd.png)

以上项目的模板创建成功了，这里需要创建项目的解决方案工程文件

### 创建解决方案

此时进入项目的目录，执行命令

```
cd YXY.Member
```

添加项目的解决方案

```
dotnet new sln -n YXY.Member
```

### 添加项目到解决方案

```
dotnet sln YXY.Member.sln add SqlSugar.Template
dotnet sln YXY.Member.sln add SqlSugar.Template.Contracts
dotnet sln YXY.Member.sln add SqlSugar.Template.Extensions
dotnet sln YXY.Member.sln add SqlSugar.Template.Models
dotnet sln YXY.Member.sln add SqlSugar.Template.Service
```

# SqlSugarScope 单例注入

```c#
SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
{
    DbType = SqlSugar.DbType.MySql,
    ConnectionString = configuration.GetConnectionString(dbName),
    IsAutoCloseConnection = true,
},
  db =>
  {
    //单例参数配置，所有上下文生效
    db.Aop.OnLogExecuting = (sql, pars) =>
      {
        Console.WriteLine(sql);//输出sql
        Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数
    };
  });
services.AddSingleton<ISqlSugarClient>(sqlSugar);

```

# 更多组件注入

```c#
//sqlsugar注入
services.AddSqlsugarSetup(Configuration);
//Swagger 注入
services.AddSwaggerGenV2();
//HttpContext注入
services.AddHttpContextSetup();
//redis注入
services.AddRedisSetup();
//认证身份注入
services.AddAuthSetup();
//还有其它更多服务可以注册。。。
//注入原码参考地址：https://github.com/hailang2ll/DMS
```

# 新增语法

```c#
//插入返回自增列
var flag = db.Insertable(jobLogEntity).ExecuteReturnIdentity();
//插入返回影响行
flag = await db.Insertable(jobLogEntity).ExecuteCommandAsync();
//null 列不插入
flag = await db.Insertable(jobLogEntity).IgnoreColumns(ignoreNullColumn: true).ExecuteCommandAsync();
//插入指定列
flag = db.Insertable(jobLogEntity).InsertColumns(it => new { it.Name, it.JobLogType }).ExecuteReturnIdentity();
flag = db.Insertable(jobLogEntity).InsertColumns("Name", "JobLogType").ExecuteReturnIdentity();

```

# 事物语法

### 同步

```
var resultTran = db.Ado.UseTran(() =>
{
    var t1 = db.Insertable(jobLogEntity).ExecuteCommand();
    var t2 = db.Insertable(jobEntity).ExecuteCommand(); //禁止里面用异步方法
});
if (!resultTran.IsSuccess)
{
    throw resultTran.ErrorException;
}
```

### 异步

```c#
var resultTran = await db.Ado.UseTranAsync(async () =>
{
    var identity = await db.Insertable(entity).ExecuteReturnBigIdentityAsync();
    await db.Insertable(productList).ExecuteCommandAsync();
});
if (!resultTran.IsSuccess)
{
    //事物失败，异常捕捉
    throw resultTran.ErrorException;
}
```

```
resultTran = await db.Ado.UseTranAsync(async () =>
{
    var t1 = await db.Insertable(jobLogEntity).ExecuteCommandAsync();
    var t2 = await db.Insertable(jobEntity).ExecuteCommandAsync();
}, e => throw e); //事物失败，异常捕捉

```

# 删除

```
var t1 = await db.Deleteable<Sys_JobLog>()
    .Where(a => a.JobLogID == jobLogID)
    .ExecuteCommandAsync();
```

# 修改

```
var t1 = await db.Updateable(
    new Sys_JobLog()
    {
        Message = "新标题",
        CreateTime = DateTime.Now
    })
    .Where(a => a.JobLogID == jobLogID)
    .ExecuteCommandAsync();
```

```
await db.Updateable<YxyInvoice>()
   .SetColumns(it => new YxyInvoice() { DeleteBy = memberId, DeleteFlag = 1, DeleteTime = DateTime.Now })
   .Where(q => q.MemberId == memberId && q.Id == param.InvoiceId)
   .ExecuteCommandAsync();
```

# 查询

### 实体查询

```c#
var entity = await db.Queryable<Sys_JobLog>()
    .Select<JobLogResult>()
    .FirstAsync(q => q.JobLogID == jobLogID);
```

### 列表查询 

```
var list = await db.Queryable<Sys_JobLog>()
    .Where(q => q.JobLogType == jobLogType)
    .Select<JobLogResult>()
    .ToListAsync();
```

### 分页列表

```
//表达式创建
var expression = Expressionable.Create<YxyInvoice>();
expression.And(m => m.CreateBy == memberId && m.InvoiceGtype == param.InvoiceGType && m.DeleteFlag == 0);
//判断条件
if (!param.AuditStateList.IsNullOrEmpty())
{
    var auditState = param.AuditStateList.Split(",").ToList();
    expression.And(m => auditState.Contains(m.AuditState.ToString()));
}
Expression<Func<YxyInvoice, bool>> where = expression.ToExpression();//必须ToExpression()

await db.Queryable<YxyInvoice>().WhereIF(where != null, where).OrderBy(m => m.ApproveState).ToPageListAsync(param.PageIndex, param.PageSize, count);
```

