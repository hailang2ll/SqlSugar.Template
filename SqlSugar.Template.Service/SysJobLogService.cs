using DMS.Common.Helper;
using DMS.Common.Model.Result;
using SqlSugar.Template.IService;
using SqlSugar.Template.IService.Param;
using SqlSugar.Template.IService.Result;
using SqlSugar.Template.Models;
using SqlSugar.Template.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SqlSugar.Template.Service
{
    /// <summary>
    /// .net ioc注入
    /// </summary>
    public class SysJobLogService : BaseRepository<SysJoblog>, ISysJobLogService
    {
        /// <summary>
        /// 各种新增语法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ResponseResult> Add(AddJobLogParam param)
        {
            ResponseResult result = new();
            if (param == null
                || string.IsNullOrEmpty(param.Name)
                || string.IsNullOrEmpty(param.Message))
            {
                result.errno = 1;
                result.errmsg = "参数错误";
                return result;
            }
            SysJoblog jobLogEntity = new()
            {
                Name = param.Name,
                JobLogtype = param.JobLogType,
                ServerIp = IPHelper.GetCurrentIp(),
                TaskLogtype = param.TaskLogType.Value,
                Message = param.Message,
                CreateTime = DateTime.Now,
            };

            //插入返回自增列
            var flag = await base.InsertReturnIdentityAsync(jobLogEntity);
            //null 列不插入
            flag = await base.AsInsertable(jobLogEntity).IgnoreColumns(ignoreNullColumn: true).ExecuteCommandAsync();
            //插入指定列
            flag = base.AsInsertable(jobLogEntity).InsertColumns(it => new { it.Name, it.JobLogtype }).ExecuteReturnIdentity();
            flag = base.AsInsertable(jobLogEntity).InsertColumns("Name", "JobLogType").ExecuteReturnIdentity();
            result.data = flag;
            return result;
        }
        /// <summary>
        /// 添加事物 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ResponseResult> AddTran(AddJobLogParam param)
        {
            ResponseResult result = new();
            if (param == null
                || string.IsNullOrEmpty(param.Name)
                || string.IsNullOrEmpty(param.Message))
            {
                result.errno = 1;
                result.errmsg = "参数错误";
                return result;
            }
            SysJoblog jobLogEntity = new()
            {
                Name = param.Name,
                JobLogtype = param.JobLogType,
                ServerIp = IPHelper.GetCurrentIp(),
                TaskLogtype = param.TaskLogType.Value,
                Message = param.Message,
                CreateTime = DateTime.Now,
            };
            SysLog jobEntity = new()
            {
                Logger = "测试数据",
                Level = "测试等级",
                Ip = "::",
                LogType = 1,
                Message = "测试数据",
                SubSysid = 1,
                SubSysname = "测试子名称",
                Thread = "测试数据",
                Url = "http://www.xxxxx.com/",
                MemberName = "name",
                CreateTime = DateTime.Now,
                Exception = "测试异常信息",
            };
            #region 事物写法1
            var resultTran = await Context.Ado.UseTranAsync(async () =>
            {
                var t1 = await Context.Insertable(jobLogEntity).ExecuteCommandAsync();
                var t2 = await Context.Insertable(jobEntity).ExecuteCommandAsync();
            });
            if (!resultTran.IsSuccess)
            {
                //捕捉异常
                throw resultTran.ErrorException;
            }
            #endregion
            #region 事物写法2-简写
            resultTran = await Context.Ado.UseTranAsync(async () =>
            {
                var t1 = await Context.Insertable(jobLogEntity).ExecuteCommandAsync();
                var t2 = await Context.Insertable(jobEntity).ExecuteCommandAsync();
            }, e => throw e);
            #endregion
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        public async Task<ResponseResult> DeleteAsync(long jobLogID)
        {
            ResponseResult result = new();
            if (jobLogID <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }

            var t1 = await Context.Deleteable<SysJoblog>()
                .Where(a => a.Id == jobLogID)
                .ExecuteCommandAsync();
            result.data = t1;
            return result;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        public async Task<ResponseResult> UpdateAsync(long jobLogID)
        {
            ResponseResult result = new();
            if (jobLogID <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }
            var t1 = await Context.Updateable(
                new SysJoblog()
                {
                    Message = "新标题",
                    CreateTime = DateTime.Now
                })
                .Where(a => a.Id == jobLogID)
                .ExecuteCommandAsync();
            result.data = t1;
            return result;

        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        public async Task<ResponseResult<JobLogResult>> GetJobLogAsync(long jobLogID)
        {
            ResponseResult<JobLogResult> result = new() { data = new JobLogResult() };
            var entity = await Context.Queryable<SysJoblog>()
                .Select<JobLogResult>()
                .FirstAsync(q => q.JobLogID == jobLogID);
            if (entity == null)
            {
                result.errno = 1;
                result.errmsg = "未找到相关数据";
                return result;
            }
            result.data = entity;
            return result;
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="jobLogType"></param>
        /// <returns></returns>
        public async Task<ResponseResult<List<JobLogResult>>> GetJobLogListAsync(long jobLogType)
        {
            ResponseResult<List<JobLogResult>> result = new()
            {
                data = new List<JobLogResult>()
            };
            if (jobLogType <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }
            var list = await Context.Queryable<SysJoblog>()
                .Where(q => q.JobLogtype == jobLogType)
                .Select<JobLogResult>()
                .ToListAsync();
            if (list == null || list.Count <= 0)
            {
                result.errno = 2;
                result.errmsg = "未找到相关数据";
                return result;
            }
            result.data = list;
            return result;
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ResponseResult<PageModel<JobLogResult>>> SearchJobLogAsync(SearchJobLogParam param)
        {
            ResponseResult<PageModel<JobLogResult>> result = new()
            {
                data = new PageModel<JobLogResult>()
            };
            if (param == null || param.JobLogType <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }

            RefAsync<int> totalCount = 0;
            var expression = Expressionable.Create<SysJoblog>();
            expression.And(m => m.JobLogtype == 1);
            Expression<Func<SysJoblog, bool>> where = expression.ToExpression();
            var list = await Context.Queryable<SysJoblog>()
                .WhereIF(where != null, where)
                .OrderBy(q => q.Id, OrderByType.Desc)
                .Select<JobLogResult>()
                .ToPageListAsync(param.pageIndex, param.pageSize, totalCount);
            if (list == null || list.Count <= 0)
            {
                result.errno = 2;
                result.errmsg = "未找到相关数据";
                return result;
            }
            result.data.resultList = list;
            result.data.pageIndex = param.pageIndex;
            result.data.pageSize = param.pageSize;
            result.data.totalRecord = (int)totalCount;
            return result;
        }
    }
}
