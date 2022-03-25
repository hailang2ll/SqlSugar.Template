using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugar.Template.Extensions.DB
{
    public class DBOptions
    {
        public string MainDB { get; set; }
        public bool MutiDBEnabled { get; set; }
        public List<MutiDBConns> MutiDBConns { get; set; }
    }
    public class MutiDBConns
    {
        /// <summary>
        /// 连接启用开关
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 连接ID
        /// </summary>
        public string ConnId { get; set; }
        /// <summary>
        /// 从库执行级别，越大越先执行
        /// </summary>
        public int HitRate { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connection { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataBaseType DbType { get; set; }
    }

    public enum DataBaseType
    {
        MySql = 0,
        SqlServer = 1,
        Sqlite = 2,
        Oracle = 3,
        PostgreSQL = 4,
        Dm = 5,
        Kdbndp = 6,
    }
}
