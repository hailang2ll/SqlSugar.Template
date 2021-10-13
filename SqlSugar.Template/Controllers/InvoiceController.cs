using DMS.Auth;
using DMSN.Common.BaseResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar.Template.Contracts;
using SqlSugar.Template.Contracts.Param;
using SqlSugar.Template.Contracts.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlSugar.Template.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        private readonly IUserAuth userAuth;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceService"></param>
        /// <param name="userAuth"></param>
        public InvoiceController(IInvoiceService invoiceService, IUserAuth userAuth)
        {
            this.invoiceService = invoiceService;
            this.userAuth = userAuth;
        }
        /// <summary>
        /// 新增工作日志
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ResponseResult> AddAsync(AddInvoiceParam param)
        {
            return await invoiceService.Add2Async(param);
        }

        /// <summary>
        /// 获取发票信息
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        [HttpGet("GetInvoice")]
        public async Task<ResponseResult<InvoiceResult>> GetInvoiceAsync(long invoiceID)
        {

            return await invoiceService.GetInvoiceAsync(invoiceID);
        }
    }
}
