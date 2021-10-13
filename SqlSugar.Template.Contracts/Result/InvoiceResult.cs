using System;

namespace SqlSugar.Template.Contracts.Result
{
    /// <summary>
    /// 返回实体
    /// </summary>
    public class InvoiceResult
    {
        /// <summary>
        /// 当前用户id(记录创建人id)
        ///</summary>
        [SugarColumn(ColumnName = "member_id")]
        public long MemberId { get; set; }
        /// <summary>
        /// 主键
        ///</summary>
        public long Id { get; set; }
        /// <summary>
        /// 报销大类型 默认值0，1增值税发票，2出行发票
        ///</summary>
        public byte InvoiceGtype { get; set; }
        /// <summary>
        /// 发票种类，11种类型
        ///</summary>
        public int InvoiceType { get; set; }
        /// <summary>
        /// 发票种类，11种类型名称
        ///</summary>
        [SugarColumn(ColumnName = "type_name")]
        public string TypeName { get; set; }
        /// <summary>
        /// 录入方式：0手输错票，1手动，2二维码
        ///</summary>
        public int EntryType { get; set; }
        /// <summary>
        /// 背书人-企业编码
        ///</summary>
        public string EpCode { get; set; }
        /// <summary>
        /// 背书人-企业名称
        ///</summary>
        public string EpName { get; set; }
        /// <summary>
        /// 背书人-企业组织架构编码
        ///</summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 背书人-企业组织架构名称
        ///</summary>
        public string OrgName { get; set; }
    }
}
