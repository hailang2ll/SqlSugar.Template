using SqlSugar.Template.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Contracts
{
    public interface IBaseServices<TEntity> where TEntity : class
    {

        Task<TEntity> QueryById(object objId);
    }
}
