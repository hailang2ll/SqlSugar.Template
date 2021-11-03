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
    throw resultTran.ErrorException;
}
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

