using SqlSugar.Template.Contracts;
using SqlSugar.Template.Models;
using SqlSugar.Template.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Service
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        //public IBaseRepository<TEntity> baseDal = new BaseRepository<TEntity>();
        public IBaseRepository<TEntity> BaseDal { get; set; }//通过在子类的构造函数中注入，这里是基类，不用构造函数

        public async Task<TEntity> QueryById(object objId)
        {
            return await BaseDal.QueryById(objId);
        }
    }
}
