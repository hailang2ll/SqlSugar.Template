using DMSN.Common.BaseParam;
using System;

namespace SqlSugar.Template.Contracts.Param
{
    /// <summary>
    /// 添加发票
    /// </summary>
    public class AddInvoiceParam
    {
        /// <summary>
        /// 当前用户id(记录创建人id)
        ///</summary>
        public long MemberId { get; set; }
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
        public string TypeName { get; set; }
    }

    public class SearchInvoiceParam
    {
        /// <summary>
        /// 当前用户id(记录创建人id)
        ///</summary>
        public long MemberId { get; set; }
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
        public string TypeName { get; set; }
    }
}
