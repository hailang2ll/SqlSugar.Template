using DMS.Common.Model.Result;
using SqlSugar.Template.IService.Param;
using SqlSugar.Template.IService.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlSugar.Template.IService
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public interface ISysLogService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ResponseResult> Add(AddSysLogParam param);
        Task<ResponseResult> AddTran(AddSysLogParam param);
    }
}
