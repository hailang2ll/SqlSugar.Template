using DMS.Common.Helper;
using DMS.Common.Model.Result;
using SqlSugar.Template.Contracts;
using SqlSugar.Template.Contracts.Param;
using SqlSugar.Template.Contracts.Result;
using SqlSugar.Template.Models;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// 各种新增语法
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ResponseResult> AddAsync(AddJobLogParam param)
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
            Sys_JobLog jobLogEntity = new()
            {
                Name = param.Name,
                JobLogType = param.JobLogType,
                ServerIP = IPHelper.GetCurrentIp(),
                TaskLogType = param.TaskLogType,
                Message = param.Message,
                CreateTime = DateTime.Now,
            };

            //插入返回自增列
            var flag = db.Insertable(jobLogEntity).ExecuteReturnIdentity();
            //插入返回影响行
            flag = await db.Insertable(jobLogEntity).ExecuteCommandAsync();
            //null 列不插入
            flag = await db.Insertable(jobLogEntity).IgnoreColumns(ignoreNullColumn: true).ExecuteCommandAsync();
            //插入指定列
            flag = db.Insertable(jobLogEntity).InsertColumns(it => new { it.Name, it.JobLogType }).ExecuteReturnIdentity();
            flag = db.Insertable(jobLogEntity).InsertColumns("Name", "JobLogType").ExecuteReturnIdentity();
            result.data = flag;
            return result;
        }
        /// <summary>
        /// 添加事物 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ResponseResult> AddTranAsync(AddJobLogParam param)
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
            Sys_JobLog jobLogEntity = new()
            {
                Name = param.Name,
                JobLogType = param.JobLogType,
                ServerIP = IPHelper.GetCurrentIp(),
                TaskLogType = param.TaskLogType,
                Message = param.Message,
                CreateTime = DateTime.Now,
            };
            Sys_Log jobEntity = new()
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
                Url = "http://www.xxxxx.com/",
                MemberName = "name",
                CreateTime = DateTime.Now,
                Exception = "测试异常信息",
            };
            #region 事物写法1
            var resultTran = await db.Ado.UseTranAsync(async () =>
            {
                var t1 = await db.Insertable(jobLogEntity).ExecuteCommandAsync();
                var t2 = await db.Insertable(jobEntity).ExecuteCommandAsync();
            });
            if (!resultTran.IsSuccess)
            {
                //捕捉异常
                throw resultTran.ErrorException;
            }
            #endregion
            #region 事物写法2-简写
            resultTran = await db.Ado.UseTranAsync(async () =>
            {
                var t1 = await db.Insertable(jobLogEntity).ExecuteCommandAsync();
                var t2 = await db.Insertable(jobEntity).ExecuteCommandAsync();
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

            var t1 = await db.Deleteable<Sys_JobLog>()
                .Where(a => a.JobLogID == jobLogID)
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
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        public async Task<ResponseResult<JobLogResult>> GetJobLogAsync(long jobLogID)
        {
            ResponseResult<JobLogResult> result = new() { data = new JobLogResult() };
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
            var list = await db.Queryable<Sys_JobLog>()
                .Where(q => q.JobLogType == jobLogType)
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
            var expression = Expressionable.Create<Sys_JobLog>();
            expression.And(m => m.JobLogType == 1);
            Expression<Func<Sys_JobLog, bool>> where = expression.ToExpression();
            var list = await db.Queryable<Sys_JobLog>()
                .WhereIF(where != null, where)
                .OrderBy(q => q.JobLogID, OrderByType.Desc)
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
