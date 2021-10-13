using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace SqlSugar.Template.Models
{
    /// <summary>
    /// 发票报销记录表
    ///</summary>
    [SugarTable("yxy_invoice")]
    public class YxyInvoice
    {
        /// <summary>
        /// 当前用户id(记录创建人id)
        ///</summary>
        [SugarColumn(ColumnName = "member_id", IsPrimaryKey = true)]
        public long MemberId { get; set; }
        /// <summary>
        /// 主键
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        /// <summary>
        /// 报销大类型 默认值0，1增值税发票，2出行发票
        ///</summary>
        [SugarColumn(ColumnName = "invoice_gtype")]
        public byte InvoiceGtype { get; set; }
        /// <summary>
        /// 发票种类，11种类型
        ///</summary>
        [SugarColumn(ColumnName = "invoice_type")]
        public int InvoiceType { get; set; }
        /// <summary>
        /// 发票种类，11种类型名称
        ///</summary>
        [SugarColumn(ColumnName = "type_name")]
        public string TypeName { get; set; }
        /// <summary>
        /// 录入方式：0手输错票，1手动，2二维码
        ///</summary>
        [SugarColumn(ColumnName = "entry_type")]
        public int EntryType { get; set; }
        /// <summary>
        /// 背书人-企业编码
        ///</summary>
        [SugarColumn(ColumnName = "ep_code")]
        public string EpCode { get; set; }
        /// <summary>
        /// 背书人-企业名称
        ///</summary>
        [SugarColumn(ColumnName = "ep_name")]
        public string EpName { get; set; }
        /// <summary>
        /// 背书人-企业组织架构编码
        ///</summary>
        [SugarColumn(ColumnName = "org_code")]
        public string OrgCode { get; set; }
        /// <summary>
        /// 背书人-企业组织架构名称
        ///</summary>
        [SugarColumn(ColumnName = "org_name")]
        public string OrgName { get; set; }
        /// <summary>
        /// 背书人部门id
        ///</summary>
        [SugarColumn(ColumnName = "department_id")]
        public long DepartmentId { get; set; }
        /// <summary>
        /// 背书人职务id
        ///</summary>
        [SugarColumn(ColumnName = "jobtitle_id")]
        public long JobtitleId { get; set; }
        /// <summary>
        /// 背书人id（报销人）
        ///</summary>
        [SugarColumn(ColumnName = "reimburse_id")]
        public long ReimburseId { get; set; }
        /// <summary>
        /// 背书人名称
        ///</summary>
        [SugarColumn(ColumnName = "reimburse_name")]
        public string ReimburseName { get; set; }
        /// <summary>
        /// 科目类型
        ///</summary>
        [SugarColumn(ColumnName = "subject_type")]
        public int SubjectType { get; set; }
        /// <summary>
        /// 科目类型名称
        ///</summary>
        [SugarColumn(ColumnName = "subject_name")]
        public string SubjectName { get; set; }
        /// <summary>
        /// 申报日期
        ///</summary>
        [SugarColumn(ColumnName = "declare_time")]
        public DateTime? DeclareTime { get; set; }
        /// <summary>
        /// 发票代码
        ///</summary>
        [SugarColumn(ColumnName = "invoice_code")]
        public string InvoiceCode { get; set; }
        /// <summary>
        /// 发票号码
        ///</summary>
        [SugarColumn(ColumnName = "invoice_number")]
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 开票日期
        ///</summary>
        [SugarColumn(ColumnName = "print_time")]
        public DateTime PrintTime { get; set; }
        /// <summary>
        /// 不含税金额(开票金额，开具金额)
        ///</summary>
        [SugarColumn(ColumnName = "total_notax_price")]
        public decimal TotalNotaxPrice { get; set; }
        /// <summary>
        /// 发票图片
        ///</summary>
        [SugarColumn(ColumnName = "invoice_pic")]
        public string InvoicePic { get; set; }
        /// <summary>
        /// 报销单备注
        ///</summary>
        [SugarColumn(ColumnName = "remark")]
        public string Remark { get; set; }
        /// <summary>
        /// 检验码
        ///</summary>
        [SugarColumn(ColumnName = "check_code")]
        public string CheckCode { get; set; }
        /// <summary>
        /// 机器码
        ///</summary>
        [SugarColumn(ColumnName = "machine_code")]
        public string MachineCode { get; set; }
        /// <summary>
        /// 购买方名称
        ///</summary>
        [SugarColumn(ColumnName = "buyer_name")]
        public string BuyerName { get; set; }
        /// <summary>
        /// 购买方纳税人识别号
        ///</summary>
        [SugarColumn(ColumnName = "buyer_taxpayer_code")]
        public string BuyerTaxpayerCode { get; set; }
        /// <summary>
        /// 购买方银行账号
        ///</summary>
        [SugarColumn(ColumnName = "buyer_bank_number")]
        public string BuyerBankNumber { get; set; }
        /// <summary>
        /// 购买方地址和电话
        ///</summary>
        [SugarColumn(ColumnName = "buyer_addres_phone")]
        public string BuyerAddresPhone { get; set; }
        /// <summary>
        /// 销售方名称
        ///</summary>
        [SugarColumn(ColumnName = "seller_name")]
        public string SellerName { get; set; }
        /// <summary>
        /// 销售方纳税人识别号
        ///</summary>
        [SugarColumn(ColumnName = "seller_taxpayer_code")]
        public string SellerTaxpayerCode { get; set; }
        /// <summary>
        /// 销售方银行账号
        ///</summary>
        [SugarColumn(ColumnName = "seller_bank_number")]
        public string SellerBankNumber { get; set; }
        /// <summary>
        /// 销售方地址和电话
        ///</summary>
        [SugarColumn(ColumnName = "seller_addres_phone")]
        public string SellerAddresPhone { get; set; }
        /// <summary>
        /// 税额
        ///</summary>
        [SugarColumn(ColumnName = "total_tax_price")]
        public decimal TotalTaxPrice { get; set; }
        /// <summary>
        /// 价税合计(金额)
        ///</summary>
        [SugarColumn(ColumnName = "total_price")]
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 发票类型名称
        ///</summary>
        [SugarColumn(ColumnName = "invoice_type_name")]
        public string InvoiceTypeName { get; set; }
        /// <summary>
        /// 发票类型编码
        ///</summary>
        [SugarColumn(ColumnName = "invoice_type_code")]
        public string InvoiceTypeCode { get; set; }
        /// <summary>
        /// 发票地区名称
        ///</summary>
        [SugarColumn(ColumnName = "invoice_area_name")]
        public string InvoiceAreaName { get; set; }
        /// <summary>
        /// 发票地区编码
        ///</summary>
        [SugarColumn(ColumnName = "invoice_area_code")]
        public string InvoiceAreaCode { get; set; }
        /// <summary>
        /// 发票备注
        ///</summary>
        [SugarColumn(ColumnName = "invoice_remark")]
        public string InvoiceRemark { get; set; }
        /// <summary>
        /// 是否为清单：0不是，1是
        ///</summary>
        [SugarColumn(ColumnName = "list_flag")]
        public byte ListFlag { get; set; }
        /// <summary>
        /// 作废标识：0正常，1作废
        ///</summary>
        [SugarColumn(ColumnName = "void_flag")]
        public byte VoidFlag { get; set; }
        /// <summary>
        /// 收货员
        ///</summary>
        [SugarColumn(ColumnName = "goods_clerk")]
        public string GoodsClerk { get; set; }
        /// <summary>
        /// 收费标识
        ///</summary>
        [SugarColumn(ColumnName = "fee_sign")]
        public string FeeSign { get; set; }
        /// <summary>
        /// 收费标识名称
        ///</summary>
        [SugarColumn(ColumnName = "fee_sign_name")]
        public string FeeSignName { get; set; }
        /// <summary>
        /// 出发城市
        ///</summary>
        [SugarColumn(ColumnName = "leave_city")]
        public string LeaveCity { get; set; }
        /// <summary>
        /// 到达城市
        ///</summary>
        [SugarColumn(ColumnName = "arrive_city")]
        public string ArriveCity { get; set; }
        /// <summary>
        /// 车次/航班/车牌
        ///</summary>
        [SugarColumn(ColumnName = "car_times")]
        public string CarTimes { get; set; }
        /// <summary>
        /// 座位类型
        ///</summary>
        [SugarColumn(ColumnName = "seat_type")]
        public int SeatType { get; set; }
        /// <summary>
        /// 座位类型名称
        ///</summary>
        [SugarColumn(ColumnName = "seat_type_name")]
        public string SeatTypeName { get; set; }
        /// <summary>
        /// 出发时间
        ///</summary>
        [SugarColumn(ColumnName = "leave_time")]
        public DateTime LeaveTime { get; set; }
        /// <summary>
        /// 到达时间
        ///</summary>
        [SugarColumn(ColumnName = "arrive_time")]
        public DateTime ArriveTime { get; set; }
        /// <summary>
        /// 车票数量
        ///</summary>
        [SugarColumn(ColumnName = "ticket_count")]
        public int TicketCount { get; set; }
        /// <summary>
        /// 座位等级
        ///</summary>
        [SugarColumn(ColumnName = "seat_level")]
        public string SeatLevel { get; set; }
        /// <summary>
        /// 行李重量
        ///</summary>
        [SugarColumn(ColumnName = "luggage_weight")]
        public decimal LuggageWeight { get; set; }
        /// <summary>
        /// 审批状态：0报销中、1未过审、2已过审
        ///</summary>
        [SugarColumn(ColumnName = "approve_state")]
        public int ApproveState { get; set; }
        /// <summary>
        /// 最新的审批意见
        ///</summary>
        [SugarColumn(ColumnName = "approve_remark")]
        public string ApproveRemark { get; set; }
        /// <summary>
        /// 审核状态：0未审核、1未过审、2已过审
        ///</summary>
        [SugarColumn(ColumnName = "audit_state")]
        public int AuditState { get; set; }
        /// <summary>
        /// 最新的审核意见
        ///</summary>
        [SugarColumn(ColumnName = "audit_remark")]
        public string AuditRemark { get; set; }
        /// <summary>
        /// 接口返回的发票字符串
        ///</summary>
        [SugarColumn(ColumnName = "invoice_json")]
        public string InvoiceJson { get; set; }
        /// <summary>
        /// 创建用户id
        ///</summary>
        [SugarColumn(ColumnName = "create_by")]
        public long CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        ///</summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改用户id
        ///</summary>
        [SugarColumn(ColumnName = "update_by")]
        public long UpdateBy { get; set; }
        /// <summary>
        /// 修改时间
        ///</summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 删除用户id
        ///</summary>
        [SugarColumn(ColumnName = "delete_by")]
        public long DeleteBy { get; set; }
        /// <summary>
        /// 是否删除：0不删除，1删除
        ///</summary>
        [SugarColumn(ColumnName = "delete_flag")]
        public byte DeleteFlag { get; set; }
        /// <summary>
        /// 删除时间
        ///</summary>
        [SugarColumn(ColumnName = "delete_time")]
        public DateTime DeleteTime { get; set; }
    }
}
