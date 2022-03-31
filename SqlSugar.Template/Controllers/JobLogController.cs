using DMS.Auth;
using DMS.Auth.Oauth2;
using DMS.Common.Model.Result;
using DMS.Redis;
using Microsoft.AspNetCore.Mvc;
using SqlSugar.Template.IService;
using SqlSugar.Template.IService.Param;
using SqlSugar.Template.IService.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlSugar.Template.Controllers
{
    /// <summary>
    /// 日志
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JobLogController : ControllerBase
    {

        private readonly ISysJobLogService jobLogService;
        private readonly IUserAuth userAuth;
        private readonly IRedisRepository redisRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobLogService"></param>
        /// <param name="userAuth"></param>
        /// <param name="redisRepository"></param>
        public JobLogController(ISysJobLogService jobLogService, IUserAuth userAuth, IRedisRepository redisRepository)
        {
            this.jobLogService = jobLogService;
            this.userAuth = userAuth;
            this.redisRepository = redisRepository;
        }
        /// <summary>
        /// 新增工作日志
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ResponseResult> AddAsync(AddJobLogParam param)
        {
            var url = DMS.Common.AppConfig.GetValue("ProductUrl");
            var de = DMS.Common.AppConfig.GetValue(new string[] { "Logging", "LogLevel", "Default" });

            var id = userAuth.ID;
            var name = userAuth.Name;

            var appid = Request.Headers["appid"];
            var accessToken = Request.Headers["AccessToken"];


            #region 缓存测试
            UserTicket userTicket = new()
            {
                ID = 1234567890,
                ExpDate = DateTime.Now,
                EpCode = "1222",
                UID = "成功0",
                Name = "肖浪",
            };
            var b = await redisRepository.SetAsync("dylan", userTicket);
            var v = await redisRepository.GetValueAsync<UserTicket>("dylan");
            #endregion

            return await jobLogService.AddAsync(param);
        }

        /// <summary>
        /// 事物处理
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("AddTran")]
        public async Task<ResponseResult> AddTranAsync(AddJobLogParam param)
        {
            return await jobLogService.AddTranAsync(param);
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        public async Task<ResponseResult> DeleteAsync(long jobLogID)
        {
            return await jobLogService.DeleteAsync(jobLogID);
        }
        /// <summary>
        /// 修改日志
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<ResponseResult> UpdateAsync(long jobLogID)
        {
            return await jobLogService.UpdateAsync(jobLogID);
        }

        /// <summary>
        /// 获取工作日志记录
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        [HttpGet("GetJobLog")]
        public async Task<ResponseResult<JobLogResult>> GetJobLogAsync(long jobLogID)
        {

            return await jobLogService.GetJobLogAsync(jobLogID);
        }

        /// <summary>
        /// 获取日志集合
        /// </summary>
        /// <param name="jobLogType"></param>
        /// <returns></returns>
        [HttpGet("GetJobLogList")]
        public async Task<ResponseResult<List<JobLogResult>>> GetJobLogListAsync(long jobLogType)
        {
            return await jobLogService.GetJobLogListAsync(jobLogType);
        }
        /// <summary>
        /// 搜索日志
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>

        [HttpGet("SearchJobLog")]
        public async Task<ResponseResult<PageModel<JobLogResult>>> SearchJobLogAsync([FromQuery] SearchJobLogParam param)
        {
            var id = userAuth.ID;
            var name = userAuth.Name;

            return await jobLogService.SearchJobLogAsync(param);
        }
    }
}
