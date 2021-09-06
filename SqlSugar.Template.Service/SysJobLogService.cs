using DMSN.Common.BaseResult;
using DMSN.Common.Extensions.ExpressionFunc;
using DMSN.Common.Helper;
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
    public class SysJobLogService : ISysJobLogService
    {
        public ISqlSugarClient db;
        public SysJobLogService(ISqlSugarClient sqlSugar)
        {
            db = sqlSugar;

        }

        public async Task<ResponseResult> AddAsync(AddJobLogParam param)
        {
            ResponseResult result = new ResponseResult();

            if (param == null
                || string.IsNullOrEmpty(param.Name)
                || string.IsNullOrEmpty(param.Message))
            {
                result.errno = 1;
                result.errmsg = "参数错误";
                return result;
            }
            Sys_JobLog jobLogEntity = new Sys_JobLog()
            {
                Name = param.Name,
                JobLogType = param.JobLogType,
                ServerIP = IPHelper.GetWebClientIp(),
                TaskLogType = param.TaskLogType,
                Message = param.Message,
                CreateTime = DateTime.Now,
            };

            //插入返回自增列
            //db.Insertable(jobLogEntity).ExecuteReturnIdentity();

            var t1 = await db.Insertable(jobLogEntity).ExecuteCommandAsync();
            result.data = t1;
            return result;
        }

        public async Task<ResponseResult> AddTranAsync(AddJobLogParam param)
        {
            ResponseResult result = new ResponseResult();
            if (param == null
                || string.IsNullOrEmpty(param.Name)
                || string.IsNullOrEmpty(param.Message))
            {
                result.errno = 1;
                result.errmsg = "参数错误";
                return result;
            }
            Sys_JobLog jobLogEntity = new Sys_JobLog()
            {
                Name = param.Name,
                JobLogType = param.JobLogType,
                ServerIP = IPHelper.GetWebClientIp(),
                TaskLogType = param.TaskLogType,
                Message = param.Message,
                CreateTime = DateTime.Now,
            };
            Sys_Log jobEntity = new Sys_Log()
            {
                Logger = "测试数据",
                Level = "测试等级",
                IP = "::",
                DeleteFlag = 0,
                LogType = 1,
                Message = "测试数据",
                SubSysID = 1,
                SubSysName = "测试子名称",
                Thread = "测试数据",
                Url = "http://www.yuxunwang.com/",
                MemberName = "18802727803",
                CreateTime = DateTime.Now,
                Exception = "测试异常信息",
            };
            db.Ado.UseTran(() =>
            {
                var t1 = db.Insertable(jobLogEntity).ExecuteCommandAsync();
                var t2 = db.Insertable(jobEntity).ExecuteCommandAsync();
            });

            return await Task.FromResult(result);
        }

        public async Task<ResponseResult> DeleteAsync(long jobLogID)
        {
            ResponseResult result = new ResponseResult();
            if (jobLogID <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }

            //var d = _fsql.Delete<SysJobLog>(new[] { 1, 2 }).ExecuteAffrows();
            //var t4 = _fsql.Delete<SysJobLog>(new { JobLogID = 3 }).ExecuteAffrows();
            //var t5 = _fsql.Delete<SysJobLog>().Where(a => a.JobLogID == 1).ExecuteAffrows();


            var t1 = await db.Deleteable<Sys_JobLog>()
                .Where(a => a.JobLogID == jobLogID)
                .ExecuteCommandAsync();
            result.data = t1;
            return result;
        }
        public async Task<ResponseResult> UpdateAsync(long jobLogID)
        {
            ResponseResult result = new ResponseResult();
            if (jobLogID <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }
            var t1 = await db.Updateable(
                new Sys_JobLog()
                {
                    Message = "新标题",
                    CreateTime = DateTime.Now
                })
                .Where(a => a.JobLogID == jobLogID)
                .ExecuteCommandAsync();
            result.data = t1;
            return result;

        }
        public async Task<ResponseResult<JobLogResult>> GetJobLogAsync(long jobLogID)
        {
            ResponseResult<JobLogResult> result = new ResponseResult<JobLogResult>() { data = new JobLogResult() };
            var entity = await db.Queryable<Sys_JobLog>()
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

        public async Task<ResponseResult<List<JobLogResult>>> GetJobLogListAsync(long jobLogType)
        {
            ResponseResult<List<JobLogResult>> result = new ResponseResult<List<JobLogResult>>()
            {
                data = new List<JobLogResult>()
            };
            if (jobLogType <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }
            var list = await db.Queryable<Sys_JobLog>()
                .Select<JobLogResult>()
                .Where(q => q.JobLogType == jobLogType)
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

        public async Task<ResponsePageResult<JobLogResult>> SearchJobLogAsync(SearchJobLogParam param)
        {
            ResponsePageResult<JobLogResult> result = new ResponsePageResult<JobLogResult>()
            {
                data = new DataResultList<JobLogResult>()
            };
            if (param == null || param.JobLogType <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }

            RefAsync<int> totalCount = 0;
            Expression<Func<Sys_JobLog, bool>> where = q => q.JobLogType == 1;
            where = where.And(q => q.TaskLogType == 1);

            var list = await db.Queryable<Sys_JobLog>()
                .WhereIF(where != null, where)
                .Select<JobLogResult>()
                .ToPageListAsync(param.PageIndex, param.PageSize, totalCount);
            if (list == null || list.Count <= 0)
            {
                result.errno = 2;
                result.errmsg = "未找到相关数据";
                return result;
            }
            result.data.ResultList = list;
            result.data.PageIndex = param.PageIndex;
            result.data.PageSize = param.PageSize;
            result.data.TotalRecord = (int)totalCount;
            return result;
        }
    }
}
