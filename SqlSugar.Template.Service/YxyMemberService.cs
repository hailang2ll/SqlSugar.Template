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
    public class YxyMemberService : IYxyMemberService
    {
        public ISqlSugarClient db;
        public YxyMemberService(ISqlSugarClient sqlSugar)
        {
            db = sqlSugar.AsTenant().GetConnection("yxy_system"); 
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="jobLogID"></param>
        /// <returns></returns>
        public async Task<ResponseResult<YxyMemberResult>> GetMemberAsync(long jobLogID)
        {

            ResponseResult<YxyMemberResult> result = new() { data = new YxyMemberResult() };
            var entity = await db.Queryable<YxyMember>()
                .Select<YxyMemberResult>()
                .FirstAsync(q => q.Id > 0);
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
        public async Task<ResponseResult<List<YxyMemberResult>>> GetMemberListAsync(long jobLogType)
        {
            ResponseResult<List<YxyMemberResult>> result = new()
            {
                data = new List<YxyMemberResult>()
            };
            if (jobLogType <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }
            var list = await db.Queryable<YxyMember>()
                .Where(q => q.Id > 0)
                .Select<YxyMemberResult>()
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
        public async Task<ResponseResult<PageModel<YxyMemberResult>>> SearchMemberAsync(SearchYxyMemberParam param)
        {
            ResponseResult<PageModel<YxyMemberResult>> result = new()
            {
                data = new PageModel<YxyMemberResult>()
            };
            if (param == null)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }

            RefAsync<int> totalCount = 0;
            var expression = Expressionable.Create<YxyMember>();
            expression.And(m => m.Id == 1);
            Expression<Func<YxyMember, bool>> where = expression.ToExpression();
            var list = await db.Queryable<YxyMember>()
                .WhereIF(where != null, where)
                .OrderBy(q => q.Id, OrderByType.Desc)
                .Select<YxyMemberResult>()
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
