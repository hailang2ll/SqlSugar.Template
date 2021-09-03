using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Models
{
    public class DbContext
    {
        //这里要public 
        //public static SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig()
        //{
        //    DbType = SqlSugar.DbType.SqlServer,
        //    ConnectionString = "",
        //    IsAutoCloseConnection = true,
        //});

        //public static SqlSugarClient Current
        //{
        //    get
        //    {
        //        Db = new SqlSugarClient(new ConnectionConfig()
        //        {
        //            DbType = SqlSugar.DbType.SqlServer,
        //            ConnectionString = "",
        //            IsAutoCloseConnection = true,
        //        });
        //        //调式代码 用来打印SQL 
        //        Db.Aop.OnLogExecuting = (sql, pars) =>
        //        {
        //            Console.WriteLine(sql);//输出sql
        //            Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数
        //        };
        //        return Db;
        //    }
        //}
        public SqlSugarClient Db;   //用来处理事务多表查询和复杂的操作
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.MySql,
                ConnectionString = "Data Source=192.168.31.211;Port=3306;User ID=devuser;Password=yxw-88888;Initial Catalog=trydou_sys;Charset=utf8;SslMode=none;Max pool size=10",
                IsAutoCloseConnection = true,
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql);//输出sql
                Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数
            };

            
            var allTables = Db.DbMaintenance.GetTableInfoList().Select(it => it.Name).ToList();
            foreach (var table in allTables)
            {
                //Db.DbFirst.IsCreateAttribute().CreateClassFile("c:\\Demo\\1", "Models");
                //Console.Write($"生成[{ table }]表 模型: ");
                //Console.WriteLine(new ToolsService().CreateModels($"..\\..\\..\\..\\{ solutionName }.Model\\Entity", solutionName, table, ""));
                //Console.Write($"生成[{ table }]表 服务: ");
                //Console.WriteLine(new ToolsService().CreateServices($"..\\..\\..\\..\\{ solutionName }.Interfaces\\Service", solutionName, table));
                //Console.Write($"生成[{ table }]表 接口: ");
                //Console.WriteLine(new ToolsService().CreateIServices($"..\\..\\..\\..\\{ solutionName }.Interfaces\\IService", solutionName, table));
            }
        }
    }
}
