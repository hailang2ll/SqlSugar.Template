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
        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration, string dbName = "db_master")
        {
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
        }
    }
}
