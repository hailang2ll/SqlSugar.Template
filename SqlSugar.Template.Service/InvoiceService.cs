using DMSN.Common.BaseResult;
using DMSN.Common.Extensions.ExpressionFunc;
using DMSN.Common.Helper;
using SqlSugar;
using SqlSugar.Template.Contracts;
using SqlSugar.Template.Contracts.Param;
using SqlSugar.Template.Contracts.Result;
using SqlSugar.Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DMSN.Common.Extensions;
using DMSN.Common;

namespace SqlSugar.Template.Service
{
    public class InvoiceService : IInvoiceService
    {
        public ISqlSugarClient db;
        public InvoiceService(ISqlSugarClient sqlSugar)
        {
            db = sqlSugar;
        }
        public async Task<ResponseResult> Add2Async(AddInvoiceParam param)
        {
            ResponseResult result = new ResponseResult();

            if (param == null
                || param.InvoiceType <= 0
                || param.EpCode.IsNullOrEmpty()
                || param.EpUserId <= 0
                || param.SubjectType <= 0
                || !param.DeclareTime.HasValue
                || param.InvoiceCode.IsNullOrEmpty()
                || param.InvoiceNumber.IsNullOrEmpty()
                || !param.PrintTime.HasValue)
            {
                result.errno = 1;
                result.errmsg = "参数错误";
                return result;
            }

            YxyInvoice entity = new YxyInvoice()//实体中必须要给默认值
            {
                MemberId = 111,
                InvoiceGtype = 1,
                InvoiceType = param.InvoiceType,//必
                EntryType = param.EntryType,
                EpCode = param.EpCode,//必
                EpName = param.EpName,
                EpCodePath = param.EpCodePath,
                EpNamePath = param.EpNamePath,
                EpUserId = param.EpUserId,//必
                EpUserTruename = param.EpUserTrueName,
                EpUserTitle = param.EpUserTitle,
                DepartmentCode = "",//需要处理
                DepartmentName = "",//需要处理
                SubjectType = param.SubjectType,//必
                SubjectName = param.SubjectName,
                DeclareTime = param.DeclareTime.HasValue ? param.DeclareTime.Value : StaticConst.DATEBEGIN,//必
                InvoiceCode = !param.InvoiceCode.IsNullOrEmpty() ? "" : param.InvoiceCode,//必   //也有乐税返回  
                InvoiceNumber = !param.InvoiceNumber.IsNullOrEmpty() ? "" : param.InvoiceNumber,//必     //也有乐税返回  
                PrintTime = param.PrintTime.HasValue ? param.PrintTime.Value : StaticConst.DATEBEGIN,//必    //也有乐税返回
                TotalNotaxPrice = param.TotalNotaxPrice,//也有乐税返回
                InvoicePic = !param.InvoicePic.IsNullOrEmpty() ? "" : param.InvoicePic,
                Remark = !param.Remark.IsNullOrEmpty() ? "" : param.Remark,

                CheckCode = !param.CheckCode.IsNullOrEmpty() ? param.CheckCode : "",//也有乐税返回
                MachineCode = !param.MachineCode.IsNullOrEmpty() ? param.MachineCode : "",//也有乐税返回
                BuyerName = !param.BuyerName.IsNullOrEmpty() ? param.BuyerName : "",//也有乐税返回
                BuyerTaxpayerCode = !param.BuyerTaxpayerCode.IsNullOrEmpty() ? param.BuyerTaxpayerCode : "",//也有乐税返回
                BuyerBankNumber = !param.BuyerBankNumber.IsNullOrEmpty() ? param.BuyerBankNumber : "",//也有乐税返回
                BuyerAddresPhone = !param.BuyerAddresPhone.IsNullOrEmpty() ? param.BuyerAddresPhone : "",//也有乐税返回
                SellerName = !param.SellerName.IsNullOrEmpty() ? param.SellerName : "",//也有乐税返回
                SellerTaxpayerCode = !param.SellerTaxpayerCode.IsNullOrEmpty() ? param.SellerTaxpayerCode : "",//也有乐税返回
                SellerBankNumber = !param.SellerBankNumber.IsNullOrEmpty() ? param.SellerBankNumber : "",//也有乐税返回
                SellerAddresPhone = !param.SellerAddresPhone.IsNullOrEmpty() ? param.SellerAddresPhone : "",//也有乐税返回
                TotalTaxPrice = param.TotalTaxPrice,//也有乐税返回
                TotalPrice = param.TotalPrice,//也有乐税返回
                ChannelType = 0,//需要处理

                InvoiceTypeName = "",//乐税返回
                InvoiceTypeCode = "",//乐税返回
                InvoiceAreaName = "",//乐税结果解析
                InvoiceAreaCode = "",//乐税结果解析
                InvoiceRemark = "",//乐税返回
                ListFlag = 0,//乐税返回
                VoidFlag = 0,//乐税返回
                GoodsClerk = "",//乐税返回
                FeeSign = "",//乐税返回
                FeeSignName = "",//乐税返回

                LeaveCity = !param.LeaveCity.IsNullOrEmpty() ? param.LeaveCity : "",
                ArriveCity = !param.ArriveCity.IsNullOrEmpty() ? param.ArriveCity : "",
                CarTimes = !param.CarTimes.IsNullOrEmpty() ? param.CarTimes : "",
                SeatType = param.SeatType,
                LeaveTime = param.LeaveTime.HasValue ? param.LeaveTime.Value : StaticConst.DATEBEGIN,
                ArriveTime = param.ArriveTime.HasValue ? param.LeaveTime.Value : StaticConst.DATEBEGIN,
                TicketCount = param.TicketCount,
                SeatLevel = !param.SeatLevel.IsNullOrEmpty() ? param.SeatLevel : "",
                LuggageWeight = param.LuggageWeight,
                ApproveState = 0,
                ApproveRemark = "",
                AuditState = 0,
                AuditRemark = "",
                InvoiceJson = "",
                CreateBy = 0,
                CreateTime = DateTime.Now,
                UpdateBy = 0,
                UpdateTime = DateTime.Now,
                DeleteBy = 0,
                DeleteFlag = 0,
                DeleteTime = DateTime.Now, 
            };

            //插入返回自增列1230
            //db.Insertable(jobLogEntity).ExecuteReturnIdentity();
            var t1 = await db.Insertable(entity).ExecuteCommandAsync();
            // t1 = await db.Insertable(entity).IgnoreColumns(ignoreNullColumn: true).ExecuteCommandAsync();
            result.data = t1;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Task<ResponseResult> AddAsync(AddInvoiceParam param)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> AddTranAsync(AddInvoiceParam param)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> DeleteAsync(long jobLogID)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult<List<InvoiceResult>>> GetInvoiceListAsync(long jobLogType)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResult<InvoiceResult>> GetInvoiceAsync(long invoiceID)
        {
            ResponseResult<InvoiceResult> result = new ResponseResult<InvoiceResult>() { data = new InvoiceResult() };


            var entity2 = await db.Queryable<YxyInvoice>().SingleAsync(q => q.MemberId == 12);

            var entity = await db.Queryable<YxyInvoice>()
                .Select<InvoiceResult>()
                .FirstAsync(q => q.Id == invoiceID);
            if (entity == null)
            {
                result.errno = 1;
                result.errmsg = "未找到相关数据";
                return result;
            }
            result.data = entity;
            return result;
        }

        public Task<ResponsePageResult<InvoiceResult>> SearchInvoiceAsync(SearchInvoiceParam param)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> UpdateAsync(long jobLogID)
        {
            throw new NotImplementedException();
        }
    }
}
