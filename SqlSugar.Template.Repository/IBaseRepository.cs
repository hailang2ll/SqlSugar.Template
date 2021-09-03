using SqlSugar.Template.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// SqlsugarClient实体
        /// </summary>
        ISqlSugarClient Db { get; }
        /// <summary>
        /// 根据Id查询实体
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        Task<TEntity> QueryById(object objId);
    }
}
