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
                || string.IsNullOrEmpty(param.EpCode))
            {
                result.errno = 1;
                result.errmsg = "参数错误";
                return result;
            }
            YxyInvoice entity = new YxyInvoice()//实体中必须要给默认值
            {
                MemberId = 111,
                //TypeName=param.TypeName,
                //还有很多字段，默认值即可
                //CreateTime = DateTime.Now,
            };

            //插入返回自增列
            //db.Insertable(jobLogEntity).ExecuteReturnIdentity();
            var t1 = await db.Insertable(entity).IgnoreColumns(ignoreNullColumn: true).ExecuteCommandAsync();
            // t1 = await db.Insertable(entity).IgnoreColumns(ignoreNullColumn: true).ExecuteCommandAsync();
            result.data = t1;
            return result;
        }

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
