using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace SqlSugar.Template.Extensions
{
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration)
        {
            ISqlSugarClient sqlSugar = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.MySql,
                ConnectionString = configuration.GetConnectionString("db_master"),
                IsAutoCloseConnection = true,
            });
            //调式代码 用来打印SQL 
            sqlSugar.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql);//输出sql
                Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数
            };

            services.AddSingleton<ISqlSugarClient>(sqlSugar);
        }
    }
}
