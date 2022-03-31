using DMS.Common.Model.Param;
using System;

namespace SqlSugar.Template.IService.Param
{
    /// <summary>
    /// 添加工作日志
    /// </summary>
    public class AddJobLogParam
    {
        /// <summary>
        /// 任务时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public int JobLogType { get; set; }
        /// <summary>
        /// 猪血消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public int? TaskLogType { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SearchJobLogParam: PageParam
    {
        /// <summary>
        /// 工作类型
        /// </summary>
        public int JobLogType { get; set; }
        /// <summary>
        /// 任务消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public int? TaskLogType { get; set; }
    }
}
