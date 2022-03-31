using DMS.Common.Model.Param;
using System;

namespace SqlSugar.Template.IService.Param
{
    /// <summary>
    /// 添加工作日志
    /// </summary>
    public class YxyMemberParam
    {
        /// <summary>
        /// 猪血消息
        /// </summary>
        public string MessMemberNameage { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SearchYxyMemberParam : PageParam
    {
        /// <summary>
        /// 任务消息
        /// </summary>
        public string MemberName { get; set; }

    }
}
