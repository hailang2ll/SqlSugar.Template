using System;

namespace SqlSugar.Template.Contracts.Result
{
    /// <summary>
    /// 返回实体
    /// </summary>
    public class YxyMemberResult
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
       
    }
}
