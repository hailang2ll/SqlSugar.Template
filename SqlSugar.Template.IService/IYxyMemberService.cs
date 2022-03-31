using DMS.Common.Model.Result;
using SqlSugar.Template.IService.Param;
using SqlSugar.Template.IService.Result;
using SqlSugar.Template.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlSugar.Template.IService
{
    /// <summary>
    /// 日志接口定义
    /// </summary>
    public interface IYxyMemberService
    {

        Task<ResponseResult> GetEntity(long id);
        /// <summary>
        /// 异步查询
        /// </summary>
        /// <returns></returns>
        Task<ResponseResult> GetList(long id);
        /// <summary>
        /// 异步查询
        /// </summary>
        /// <returns></returns>
        Task<ResponseResult<PageModel<YxyMemberResult>>> SearchMemberAsync(SearchYxyMemberParam param);
    }
}
