using DMS.Common.Model.Result;
using SqlSugar.Template.Contracts.Param;
using SqlSugar.Template.Contracts.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlSugar.Template.Contracts
{
    /// <summary>
    /// 日志接口定义
    /// </summary>
    public interface IYxyMemberService
    {
       
        /// <summary>
        /// 异步查询
        /// </summary>
        /// <returns></returns>
        Task<ResponseResult<YxyMemberResult>> GetMemberAsync(long jobLogID);
        /// <summary>
        /// 异步查询
        /// </summary>
        /// <returns></returns>
        Task<ResponseResult<List<YxyMemberResult>>> GetMemberListAsync(long jobLogType);
        /// <summary>
        /// 异步查询
        /// </summary>
        /// <returns></returns>
        Task<ResponseResult<PageModel<YxyMemberResult>>> SearchMemberAsync(SearchYxyMemberParam param);
    }
}
