using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using SqlSugar.Template.Extensions.DB;
using SqlSugar.IOC;

namespace SqlSugar.Template.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlsugarSetup
    {
        /// <summary>
        /// .NET单例注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var listConfig = new List<ConnectionConfig>();
            var allCon = DBConfig.MutiInitConn();
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

        /// <summary>
        /// SqlSugar.IOC注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSqlsugarIocSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var listConfig = new List<IocConfig>();
            var allCon = DBConfig.MutiInitConn();
            allCon.ForEach(q =>
            {
                listConfig.Add(new IocConfig()
                {
                    DbType = (IocDbType)q.DbType,
                    ConnectionString = q.Connection,
                    IsAutoCloseConnection = true,
                    ConfigId = q.ConnId,
                });
            });

            services.AddSqlSugar(listConfig);
            //配置参数
            services.ConfigurationSugar(db =>
            {
                allCon.ForEach(q =>
                {
                    db.GetConnection(q.ConnId).Aop.OnLogExecuting = (sql, p) =>
                    {
                        Console.WriteLine(sql);//输出sql
                        Console.WriteLine(string.Join(",", p?.Select(it => it.ParameterName + ":" + it.Value)));//参数
                    };
                });
                //设置更多连接参数
                //db.CurrentConnectionConfig.XXXX=XXXX
                //db.CurrentConnectionConfig.MoreSettings=new ConnMoreSettings(){}
                //二级缓存设置
                //db.CurrentConnectionConfig.ConfigureExternalServices = new ConfigureExternalServices()
                //{
                // DataInfoCacheService = myCache //配置我们创建的缓存类
                //}
                //读写分离设置
                //laveConnectionConfigs = new List<SlaveConnectionConfig>(){...}

                /*多租户注意*/
                //单库是db.CurrentConnectionConfig 
                //多租户需要db.GetConnection(configId).CurrentConnectionConfig 
            });
        }
    }
}
