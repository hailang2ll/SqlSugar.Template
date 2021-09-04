using System;

namespace SqlSugar.Template.Contracts.Result
{
    /// <summary>
    /// 返回实体
    /// </summary>
    public class JobLogResult
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        public int JobLogID { get; set; }
        /// <summary>
        /// 任务时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 任务类型
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
        /// IP
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public int? TaskLogType { get; set; }
    }
}
