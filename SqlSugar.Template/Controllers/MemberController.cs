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
        /// 添加用户-同库事物
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ResponseResult> Add(AddMemberParam param)
        {
            var a = await _memberService.Add(param);
            return a;
        }
        /// <summary>
        /// 添加用户-切换仓库不同库事物
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("AddTran")]
        public async Task<ResponseResult> AddTran(AddMemberParam param)
        {
            var a = await _memberService.AddTran(param);
            return a;
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        [HttpGet("GetEntity")]
        public async Task<ResponseResult> GetEntity(long jobLogID)
        {
            var a = await _memberService.GetEntity(jobLogID);
            return a;
        }
        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="jobLogType"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        public async Task<ResponseResult> GetList(long jobLogType)
        {
            return await _memberService.GetList(jobLogType);
        }
        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet("GetPageList")]
        public async Task<ResponseResult> GetPageList([FromQuery] SearchYxyMemberParam param)
        {
            return await _memberService.GetList(param);
        }
    }
}
