using DMS.Common.Model.Param;
using DMS.Common.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region 实体查询,select()用法
        Task<TResult> GetEntity<TResult>(object objId);
        Task<TResult> GetEntity<TResult>(Expression<Func<TEntity, bool>> predicate);
        Task<TResult> GetEntity<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> predicate);
        #endregion


        #region 查询列表，TEntity查询扩展
        Task<List<TEntity>> QueryList(string strOrderByFileds);
        Task<List<TEntity>> QueryList(Expression<Func<TEntity, bool>> predicate, string strOrderByFileds);
        Task<List<TEntity>> QueryList(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        #endregion

        #region 查询列表,select<dto>()用法
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, bool>> predicate = null);
        Task<List<TResult>> QueryList<TResult>(string strOrderByFileds);
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, bool>> predicate, string strOrderByFileds);
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        #endregion

        #region 查询列表,select(expression)表达式用法
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> predicate = null);
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, string strOrderByFileds);
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> predicate, string strOrderByFileds);
        Task<List<TResult>> QueryList<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        #endregion

        #region 查询列表,分页用法
        Task<List<TEntity>> QueryList(Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, string strOrderByFileds = null);
        Task<PageModel<TEntity>> QueryPageList(Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, string strOrderByFileds = null);
        Task<PageModel<TEntity>> QueryPageList(Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        Task<PageModel<TResult>> QueryPageList<TResult>(Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, string strOrderByFileds = null);
        Task<PageModel<TResult>> QueryPageList<TResult>(Expression<Func<TEntity, TResult>> selectExpression, Expression<Func<TEntity, bool>> whereExpression, PageParam pageParam, string strOrderByFileds = null);
        #endregion
    }
}
