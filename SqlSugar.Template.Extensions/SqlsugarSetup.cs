using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using SqlSugar.Template.Extensions.DB;

namespace SqlSugar.Template.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var listConfig = new List<ConnectionConfig>();
            var allCon = DBConfig.MutiInitConn();

            //循环数据库连接
            allCon.ForEach(q =>
            {
                listConfig.Add(new ConnectionConfig()
                {
                    DbType = (DbType)q.DbType,
                    ConnectionString = q.Connection,
                    IsAutoCloseConnection = true,
                    ConfigId = q.ConnId,
                });
            });
            SqlSugarScope sqlSugar = new SqlSugarScope(listConfig,
            db =>
            {
                //循环输出sql
                allCon.ForEach(q =>
                {
                    db.GetConnection(q.ConnId).Aop.OnLogExecuting = (sql, pars) =>
                    {
                        Console.WriteLine(sql);//输出sql
                        Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数
                    };
                });

            });
            services.AddSingleton<ISqlSugarClient>(sqlSugar);
        }
    }
}
