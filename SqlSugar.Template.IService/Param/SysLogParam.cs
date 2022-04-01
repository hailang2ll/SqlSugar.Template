using DMS.Common.Model.Param;
using System;

namespace SqlSugar.Template.IService.Param
{
    /// <summary>
    /// 添加系统日志
    /// </summary>
    public class AddSysLogParam
    {
        public string MemberName { get; set; }
        public int SubSysid { get; set; }
        public string SubSysname { get; set; }
    }

}
