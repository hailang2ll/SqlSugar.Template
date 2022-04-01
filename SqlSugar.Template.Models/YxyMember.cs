using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace SqlSugar.Template.Models
{
    /// <summary>
    /// 用户表
    ///</summary>
    [SugarTable("yxy_member")]
    [TenantAttribute("yxy_system")]

    public class YxyMember
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        /// <summary>
        /// 用户名 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "member_name")]
        public string MemberName { get; set; }
        /// <summary>
        /// 登录密码 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }
        /// <summary>
        /// 0新密码 1旧密码 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "password_type")]
        public int PasswordType { get; set; }
        /// <summary>
        /// 真实姓名 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "true_name")]
        public string TrueName { get; set; }
        /// <summary>
        /// 手机号 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "mobile")]
        public string Mobile { get; set; }
        /// <summary>
        /// 手机号是否验证,0否 1是 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "mobile_flag")]
        public int MobileFlag { get; set; }
        /// <summary>
        /// 邮箱 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "email")]
        public string Email { get; set; }
        /// <summary>
        /// 邮箱是否验证,0否 1是 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "email_flag")]
        public int EmailFlag { get; set; }
        /// <summary>
        /// 性别 1男,2女 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "sex_type")]
        public int SexType { get; set; }
        /// <summary>
        /// qq 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "qq")]
        public string Qq { get; set; }
        /// <summary>
        /// 启用状态 默认0，1不通过，4通过 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "status_flag")]
        public int StatusFlag { get; set; }
        /// <summary>
        /// 不通过原因 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "disable_reason")]
        public string DisableReason { get; set; }
        /// <summary>
        /// 名片 url 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "card_image_path")]
        public string CardImagePath { get; set; }
        /// <summary>
        /// 创建时间 
        /// 默认值: CURRENT_TIMESTAMP
        ///</summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 注册渠道 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "channel_type")]
        public int ChannelType { get; set; }
    }
}
