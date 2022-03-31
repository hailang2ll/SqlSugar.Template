using DMS.Common.Model.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar.Template.IService;
using SqlSugar.Template.IService.Param;
using SqlSugar.Template.IService.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlSugar.Template.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IYxyMemberService _memberService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberService"></param>
        public MemberController(IYxyMemberService memberService)
        {
            this._memberService = memberService;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        [HttpGet("GetJobLog")]
        public async Task<ResponseResult> GetMemberAsync(long jobLogID)
        {
            var a = await _memberService.GetEntity(jobLogID);
            return a;
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="jobLogType"></param>
        /// <returns></returns>
        [HttpGet("GetJobLogList")]
        public async Task<ResponseResult> GetMemberListAsync(long jobLogType)
        {
            return await _memberService.GetList(jobLogType);
        }
        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>

        [HttpGet("SearchJobLog")]
        public async Task<ResponseResult<PageModel<YxyMemberResult>>> SearchMemberAsync([FromQuery] SearchYxyMemberParam param)
        {


            return await _memberService.SearchMemberAsync(param);
        }
    }
}
