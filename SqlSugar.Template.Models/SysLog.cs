using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace SqlSugar.Template.Models
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sys_log")]
    public class SysLog
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public long Id { get; set; }
        /// <summary>
        /// 会员名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "member_name")]
        public string MemberName { get; set; }
        /// <summary>
        /// 类型id 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "sub_sysid")]
        public int SubSysid { get; set; }
        /// <summary>
        /// 类型名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "sub_sysname")]
        public string SubSysname { get; set; }
        /// <summary>
        /// ip 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "ip")]
        public string Ip { get; set; }
        /// <summary>
        /// url 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "url")]
        public string Url { get; set; }
        /// <summary>
        /// 线程 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "thread")]
        public string Thread { get; set; }
        /// <summary>
        /// 级别类型 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "level")]
        public string Level { get; set; }
        /// <summary>
        /// 日志 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "logger")]
        public string Logger { get; set; }
        /// <summary>
        /// 消息 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "message")]
        public string Message { get; set; }
        /// <summary>
        /// 日志类型 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "log_type")]
        public int LogType { get; set; }
        /// <summary>
        /// 异常消息 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "exception")]
        public string Exception { get; set; }
        /// <summary>
        /// 创建时间 
        /// 默认值: CURRENT_TIMESTAMP
        ///</summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
