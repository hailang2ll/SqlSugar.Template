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
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "member_id", IsPrimaryKey = true)]
        public long MemberId { get; set; } = 0;
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        /// <summary>
        /// 报销大类型 默认值0，1增值税发票，2出行发票 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "invoice_gtype")]
        public byte InvoiceGtype { get; set; } = 0;
        /// <summary>
        /// 发票种类，11种类型 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "invoice_type")]
        public int InvoiceType { get; set; } = 0;
        /// <summary>
        /// 录入方式：0默认，1手动，2二维码  
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "entry_type")]
        public int EntryType { get; set; } = 0;
        /// <summary>
        /// 背书人-企业编码 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "ep_code")]
        public string EpCode { get; set; }
        /// <summary>
        /// 背书人-企业名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "ep_name")]
        public string EpName { get; set; }
        /// <summary>
        /// 背书人-企业组织架构编码路径 如 ^123^456^789^ 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "ep_code_path")]
        public string EpCodePath { get; set; }
        /// <summary>
        /// 背书人-企业名称路径 如 ^123^456^789^ 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "ep_name_path")]
        public string EpNamePath { get; set; }
        /// <summary>
        /// 背书人id（报销人 企业员工表） 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "ep_user_id")]
        public long EpUserId { get; set; } = 0;
        /// <summary>
        /// 背书人真实姓名（报销人 企业员工表） 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "ep_user_truename")]
        public string EpUserTruename { get; set; }
        /// <summary>
        /// 背书人职务 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "ep_user_title")]
        public string EpUserTitle { get; set; }
        /// <summary>
        /// 背书人部门code 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "department_code")]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// 部门名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "department_name")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 科目类型 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "subject_type")]
        public int SubjectType { get; set; } = 0;
        /// <summary>
        /// 科目类型名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "subject_name")]
        public string SubjectName { get; set; }
        /// <summary>
        /// 申报日期 
        /// 默认值: 1900-01-01 00:00:00
        ///</summary>
        [SugarColumn(ColumnName = "declare_time")]
        public DateTime DeclareTime { get; set; } = Convert.ToDateTime("1900-01-01 00:00:00");
        /// <summary>
        /// 发票代码 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_code")]
        public string InvoiceCode { get; set; }
        /// <summary>
        /// 发票号码 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_number")]
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 开票日期 
        /// 默认值: 1900-01-01 00:00:00
        ///</summary>
        [SugarColumn(ColumnName = "print_time")]
        public DateTime PrintTime { get; set; } = Convert.ToDateTime("1900-01-01 00:00:00");
        /// <summary>
        /// 不含税金额(开票金额，开具金额) 
        /// 默认值: 0.00
        ///</summary>
        [SugarColumn(ColumnName = "total_notax_price")]
        public decimal TotalNotaxPrice { get; set; } = 0;
        /// <summary>
        /// 发票图片 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_pic")]
        public string InvoicePic { get; set; }
        /// <summary>
        /// 报销单备注 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "remark")]
        public string Remark { get; set; }
        /// <summary>
        /// 检验码 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "check_code")]
        public string CheckCode { get; set; }
        /// <summary>
        /// 机器码 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "machine_code")]
        public string MachineCode { get; set; }
        /// <summary>
        /// 购买方名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "buyer_name")]
        public string BuyerName { get; set; }
        /// <summary>
        /// 购买方纳税人识别号 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "buyer_taxpayer_code")]
        public string BuyerTaxpayerCode { get; set; }
        /// <summary>
        /// 购买方银行账号 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "buyer_bank_number")]
        public string BuyerBankNumber { get; set; }
        /// <summary>
        /// 购买方地址和电话 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "buyer_addres_phone")]
        public string BuyerAddresPhone { get; set; }
        /// <summary>
        /// 销售方名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "seller_name")]
        public string SellerName { get; set; }
        /// <summary>
        /// 销售方纳税人识别号 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "seller_taxpayer_code")]
        public string SellerTaxpayerCode { get; set; }
        /// <summary>
        /// 销售方银行账号 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "seller_bank_number")]
        public string SellerBankNumber { get; set; }
        /// <summary>
        /// 销售方地址和电话 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "seller_addres_phone")]
        public string SellerAddresPhone { get; set; }
        /// <summary>
        /// 税额 
        /// 默认值: 0.00
        ///</summary>
        [SugarColumn(ColumnName = "total_tax_price")]
        public decimal TotalTaxPrice { get; set; } = 0;
        /// <summary>
        /// 价税合计(金额) 
        /// 默认值: 0.00
        ///</summary>
        [SugarColumn(ColumnName = "total_price")]
        public decimal TotalPrice { get; set; } = 0;
        /// <summary>
        /// 渠道类型  如 0默认,100乐税 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "channel_type")]
        public int ChannelType { get; set; } = 0;
        /// <summary>
        /// 发票类型名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_type_name")]
        public string InvoiceTypeName { get; set; }
        /// <summary>
        /// 发票类型编码 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_type_code")]
        public string InvoiceTypeCode { get; set; }
        /// <summary>
        /// 发票地区名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_area_name")]
        public string InvoiceAreaName { get; set; }
        /// <summary>
        /// 发票地区编码 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_area_code")]
        public string InvoiceAreaCode { get; set; }
        /// <summary>
        /// 发票备注 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_remark")]
        public string InvoiceRemark { get; set; }
        /// <summary>
        /// 是否为清单：0不是，1是 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "list_flag")]
        public byte ListFlag { get; set; } = 0;
        /// <summary>
        /// 作废标识：0正常，1作废 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "void_flag")]
        public byte VoidFlag { get; set; } = 0;
        /// <summary>
        /// 收货员 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "goods_clerk")]
        public string GoodsClerk { get; set; }
        /// <summary>
        /// 收费标识 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "fee_sign")]
        public string FeeSign { get; set; }
        /// <summary>
        /// 收费标识名称 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "fee_sign_name")]
        public string FeeSignName { get; set; }
        /// <summary>
        /// 出发城市 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "leave_city")]
        public string LeaveCity { get; set; }
        /// <summary>
        /// 到达城市 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "arrive_city")]
        public string ArriveCity { get; set; }
        /// <summary>
        /// 车次/航班/车牌 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "car_times")]
        public string CarTimes { get; set; }
        /// <summary>
        /// 座位类型 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "seat_type")]
        public int SeatType { get; set; } = 0;
        /// <summary>
        /// 出发时间 
        /// 默认值: 1900-01-01 00:00:00
        ///</summary>
        [SugarColumn(ColumnName = "leave_time")]
        public DateTime LeaveTime { get; set; } = Convert.ToDateTime("1900-01-01 00:00:00");
        /// <summary>
        /// 到达时间 
        /// 默认值: 1900-01-01 00:00:00
        ///</summary>
        [SugarColumn(ColumnName = "arrive_time")]
        public DateTime ArriveTime { get; set; } = Convert.ToDateTime("1900-01-01 00:00:00");
        /// <summary>
        /// 车票数量 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "ticket_count")]
        public int TicketCount { get; set; } = 0;
        /// <summary>
        /// 座位等级 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "seat_level")]
        public string SeatLevel { get; set; }
        /// <summary>
        /// 行李重量 
        /// 默认值: 0.00
        ///</summary>
        [SugarColumn(ColumnName = "luggage_weight")]
        public decimal LuggageWeight { get; set; } = 0;
        /// <summary>
        /// 审批状态：0报销中、1未过审、2已过审 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "approve_state")]
        public int ApproveState { get; set; } = 0;
        /// <summary>
        /// 最新的审批意见 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "approve_remark")]
        public string ApproveRemark { get; set; }
        /// <summary>
        /// 审核状态：0未审核、1未过审、2已过审 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "audit_state")]
        public int AuditState { get; set; } = 0;
        /// <summary>
        /// 最新的审核意见 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "audit_remark")]
        public string AuditRemark { get; set; }
        /// <summary>
        /// 接口返回的发票字符串 
        /// 默认值: 
        ///</summary>
        [SugarColumn(ColumnName = "invoice_json")]
        public string InvoiceJson { get; set; }
        /// <summary>
        /// 创建用户id 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "create_by")]
        public long CreateBy { get; set; } = 0;
        /// <summary>
        /// 创建时间 
        /// 默认值: CURRENT_TIMESTAMP
        ///</summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改用户id 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "update_by")]
        public long UpdateBy { get; set; } = 0;
        /// <summary>
        /// 修改时间 
        /// 默认值: 1900-01-01 00:00:00
        ///</summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime UpdateTime { get; set; } = Convert.ToDateTime("1900-01-01 00:00:00");
        /// <summary>
        /// 删除用户id 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "delete_by")]
        public long DeleteBy { get; set; } = 0;
        /// <summary>
        /// 是否删除：0不删除，1删除 
        /// 默认值: 0
        ///</summary>
        [SugarColumn(ColumnName = "delete_flag")]
        public byte DeleteFlag { get; set; } = 0;
        /// <summary>
        /// 删除时间 
        /// 默认值: 1900-01-01 00:00:00
        ///</summary>
        [SugarColumn(ColumnName = "delete_time")]
        public DateTime DeleteTime { get; set; } = Convert.ToDateTime("1900-01-01 00:00:00");
    }
}
