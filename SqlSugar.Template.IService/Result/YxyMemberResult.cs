using System;

namespace SqlSugar.Template.IService.Result
{
    /// <summary>
    /// 返回实体
    /// </summary>
    public class YxyMemberResult
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "id")]
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "member_name")]
        public string MemberName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }
       
    }
}
