using DMSN.Common.BaseParam;
using System;

namespace SqlSugar.Template.Contracts.Param
{
    /// <summary>
    /// 发票报销记录实体
    /// </summary>
    public class AddInvoiceParam
    {
        #region 基本信息
        /// <summary>
        /// 发票种类，11种类型
        ///</summary>
        public int InvoiceType { get; set; }
        /// <summary>
        /// 录入方式：1手动，2二维码
        ///</summary>
        public int EntryType { get; set; }
        /// <summary>
        /// 背书人-企业编码
        /// </summary>
        public string EpCode { get; set; }
        /// <summary>
        /// 背书人-企业名称
        /// </summary>
        public string EpName { get; set; }
        /// <summary>
        /// 背书人-企业组织架构编码路径 如 ^123^456^789^
        ///</summary>
        public string EpCodePath { get; set; }
        /// <summary>
        /// 背书人-企业组织架构编码路径 如 ^123^456^789^
        ///</summary>
        public string EpNamePath { get; set; }
        /// <summary>
        /// 背书人id（报销人）
        ///</summary>
        public long EpUserId { get; set; }
        /// <summary>
        /// 背书人名称
        ///</summary>
        public string EpUserTrueName { get; set; }
        /// <summary>
        /// 背书人职务
        /// </summary>
        public string EpUserTitle { get; set; }
        /// <summary>
        /// 科目类型
        ///</summary>
        public int SubjectType { get; set; }
        /// <summary>
        /// 科目类型名称
        ///</summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// 申报日期
        ///</summary>
        public DateTime? DeclareTime { get; set; }
        /// <summary>
        /// 发票代码
        ///</summary>
        public string InvoiceCode { get; set; }
        /// <summary>
        /// 发票号码
        ///</summary>
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 开票日期
        ///</summary>
        public DateTime PrintTime { get; set; }
        /// <summary>
        /// 不含税金额(开票金额，开具金额)
        ///</summary>
        public decimal TotalNotaxPrice { get; set; }
        /// <summary>
        /// 发票图片
        ///</summary>
        public string InvoicePic { get; set; }
        /// <summary>
        /// 报销单备注
        ///</summary>
        public string Remark { get; set; }
        #endregion

        #region 手动输入
        /// <summary>
        /// 检验码
        ///</summary>
        public string CheckCode { get; set; }
        /// <summary>
        /// 机器码
        ///</summary>
        public string MachineCode { get; set; }
        /// <summary>
        /// 购买方名称
        ///</summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// 购买方纳税人识别号
        ///</summary>
        public string BuyerTaxpayerCode { get; set; }
        /// <summary>
        /// 购买方银行账号
        ///</summary>
        public string BuyerBankNumber { get; set; }
        /// <summary>
        /// 购买方地址和电话
        ///</summary>
        public string BuyerAddresPhone { get; set; }
        /// <summary>
        /// 销售方名称
        ///</summary>
        public string SellerName { get; set; }
        /// <summary>
        /// 销售方纳税人识别号
        ///</summary>
        public string SellerTaxpayerCode { get; set; }
        /// <summary>
        /// 销售方银行账号
        ///</summary>
        public string SellerBankNumber { get; set; }
        /// <summary>
        /// 销售方地址和电话
        ///</summary>
        public string SellerAddresPhone { get; set; }
        /// <summary>
        /// 价税合计（金额）
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal TotalTaxPrice { get; set; }
        #endregion

        #region 火车票，汽车票，定额发票，长途汽车票，飞机票
        /// <summary>
        /// 出发城市
        ///</summary>
        public string LeaveCity { get; set; }
        /// <summary>
        /// 到达城市
        ///</summary>
        public string ArriveCity { get; set; }
        /// <summary>
        /// 车次/航班/车牌
        ///</summary>
        public string CarTimes { get; set; }
        /// <summary>
        /// 座位类型
        ///</summary>
        public int SeatType { get; set; }
        /// <summary>
        /// 出发时间
        ///</summary>
        public DateTime LeaveTime { get; set; }
        /// <summary>
        /// 到达时间
        ///</summary>
        public DateTime ArriveTime { get; set; }
        /// <summary>
        /// 车票数量
        ///</summary>
        public int TicketCount { get; set; }
        /// <summary>
        /// 座位等级
        ///</summary>
        public string SeatLevel { get; set; }
        /// <summary>
        /// 行李重量
        /// </summary>
        public decimal LuggageWeight { get; set; }
        #endregion
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
