using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace SqlSugar.Template.Models
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("sys_joblog")]
    public class SysJoblog
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        /// <summary>
        /// 名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 消息 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "message")]
        public string Message { get; set; }
        /// <summary>
        /// 任务类型 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "task_logtype")]
        public int TaskLogtype { get; set; }
        /// <summary>
        /// 工作日志类型 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "job_logtype")]
        public int JobLogtype { get; set; }
        /// <summary>
        /// ip地址 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "server_ip")]
        public string ServerIp { get; set; }
        /// <summary>
        /// 创建时间 
        /// 默认值: CURRENT_TIMESTAMP
        ///</summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
