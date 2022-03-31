using DMS.Common.Model.Param;
using DMS.Common.Model.Result;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace SqlSugar.Template.Repository
{
    /// <summary>
    /// 基础仓库
    /// 适用ioc注入：services.AddSqlsugarIocSetup(Configuration);
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {
        public ITenant itenant = null;//多租户事务
        public BaseRepository(ISqlSugarClient context = null) : base(context)
        {
            //通过特性拿到ConfigId
            base.Context = DbScoped.SugarScope;
            var configId = typeof(TEntity).GetCustomAttribute<TenantAttribute>()?.configId;
            if (configId != null)
            {
                base.Context = DbScoped.SugarScope.GetConnection(configId);
            }
            itenant = DbScoped.SugarScope;//设置租户接口
        }

        #region 实体查询,select()用法
        public async Task<TResult> GetEntity<TResult>(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Queryable<TEntity>().Where(predicate).Select<TResult>().FirstAsync();
        }
        public async Task<TResult> GetEntity<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Queryable<TEntity>().Where(predicate).Select(expression).FirstAsync();
        }
        #endregion





        #region 查询列表，TEntity查询扩展
        public async Task<List<TEntity>> QueryList(string strOrderByFileds)
        {
            return await Context.Queryable<TEntity>().OrderBy(strOrderByFileds).ToListAsync();
        }
        public async Task<List<TEntity>> QueryList(Expression<Func<TEntity, bool>> predicate, string strOrderByFileds)
        {
            return await Context.Queryable<TEntity>().WhereIF(predicate != null, predicate).OrderByIF(strOrderByFileds != null, strOrderByFileds).ToListAsync();
        }
        public async Task<List<TEntity>> QueryList(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await Context.Queryable<TEntity>().WhereIF(predicate != null, predicate).OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).ToListAsync();
        }
        #endregion

        #region 查询列表,select<dto>()用法
        /// <summary>
        /// 查询列表
        /// select<dto>()用法
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Context.Queryable<TEntity>().WhereIF(predicate != null, predicate).Select<TResult>().ToListAsync();
        }
        public async Task<List<TResult>> QueryList<TResult>(string strOrderByFileds)
        {
            return await Context.Queryable<TEntity>().OrderBy(strOrderByFileds).Select<TResult>().ToListAsync();
        }
        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await Context.Queryable<TEntity>().OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).Select<TResult>().ToListAsync();
        }

        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, bool>> predicate, string strOrderByFileds)
        {
            return await Context.Queryable<TEntity>().WhereIF(predicate != null, predicate).OrderByIF(strOrderByFileds != null, strOrderByFileds).Select<TResult>().ToListAsync();
        }
        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await Context.Queryable<TEntity>().WhereIF(predicate != null, predicate).OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).Select<TResult>().ToListAsync();
        }
        #endregion

        #region 查询列表,select(expression)表达式用法
        /// <summary>
        /// 查询列表
        /// select(expression)表达式用法
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Context.Queryable<TEntity>().WhereIF(predicate != null, predicate).Select(expression).ToListAsync();
        }
        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, string strOrderByFileds)
        {
            return await Context.Queryable<TEntity>().OrderBy(strOrderByFileds).Select(expression).ToListAsync();
        }
        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await Context.Queryable<TEntity>().OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).Select(expression).ToListAsync();
        }
        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> predicate, string strOrderByFileds)
        {
            return await Context.Queryable<TEntity>().WhereIF(predicate != null, predicate).OrderByIF(strOrderByFileds != null, strOrderByFileds).Select(expression).ToListAsync();
        }
        public async Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await Context.Queryable<TEntity>().WhereIF(predicate != null, predicate).OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).Select(expression).ToListAsync();
        }
        #endregion

        #region 查询列表,分页用法
        public async Task<List<TEntity>> QueryList(Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, string strOrderByFileds = null)
        {
            return await Context.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(whereExpression != null, whereExpression).ToPageListAsync(pageParam.pageIndex, pageParam.pageSize);
        }
        public async Task<PageModel<TEntity>> QueryPageList(Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, string strOrderByFileds = null)
        {
            RefAsync<int> totalCount = 0;
            var list = await Context.Queryable<TEntity>()
             .WhereIF(whereExpression != null, whereExpression)
             .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
             .ToPageListAsync(pageParam.pageIndex, pageParam.pageSize, totalCount);

            return new PageModel<TEntity>() { pageIndex = pageParam.pageIndex, pageSize = pageParam.pageSize, totalRecord = totalCount, resultList = list };
        }
        public async Task<PageModel<TEntity>> QueryPageList(Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            RefAsync<int> totalCount = 0;
            var list = await Context.Queryable<TEntity>()
             .WhereIF(whereExpression != null, whereExpression)
             .OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc)
             .ToPageListAsync(pageParam.pageIndex, pageParam.pageSize, totalCount);

            return new PageModel<TEntity>() { pageIndex = pageParam.pageIndex, pageSize = pageParam.pageSize, totalRecord = totalCount, resultList = list };
        }
        public async Task<PageModel<TResult>> QueryPageList<TResult>(Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, string strOrderByFileds = null)
        {
            RefAsync<int> totalCount = 0;
            var list = await Context.Queryable<TEntity>()
             .WhereIF(whereExpression != null, whereExpression)
             .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
             .Select<TResult>()
             .ToPageListAsync(pageParam.pageIndex, pageParam.pageSize, totalCount);

            return new PageModel<TResult>() { pageIndex = pageParam.pageIndex, pageSize = pageParam.pageSize, totalRecord = totalCount, resultList = list };
        }
        public async Task<PageModel<TResult>> QueryPageList<TResult>(Expression<Func<TEntity, TResult>> selectExpression, Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, string strOrderByFileds = null)
        {
            RefAsync<int> totalCount = 0;
            var list = await Context.Queryable<TEntity>()
             .WhereIF(whereExpression != null, whereExpression)
             .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
             .Select(selectExpression)
             .ToPageListAsync(pageParam.pageIndex, pageParam.pageSize, totalCount);

            return new PageModel<TResult>() { pageIndex = pageParam.pageIndex, pageSize = pageParam.pageSize, totalRecord = totalCount, resultList = list };
        }

        #endregion


    }
}
