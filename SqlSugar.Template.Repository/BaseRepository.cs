using SqlSugar.Extensions;
using SqlSugar.Template.Models;
using SqlSugar.Template.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()

    {
        private readonly IUnitOfWork _unitOfWork;
        private SqlSugarClient _dbBase;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbBase = unitOfWork.GetDbClient();
        }
        private ISqlSugarClient _db
        {
            get
            {
                /* 如果要开启多库支持，
                 * 1、在appsettings.json 中开启MutiDBEnabled节点为true，必填
                 * 2、设置一个主连接的数据库ID，节点MainDB，对应的连接字符串的Enabled也必须true，必填
                 */
                var flag = Appsettings.app(new string[] { "MutiDBEnabled" }).ObjToBool();
                if (flag)
                {
                    if (typeof(TEntity).GetTypeInfo().GetCustomAttributes(typeof(SugarTable), true).FirstOrDefault((x => x.GetType() == typeof(SugarTable))) is SugarTable sugarTable && !string.IsNullOrEmpty(sugarTable.TableDescription))
                    {
                        _dbBase.ChangeDatabase(sugarTable.TableDescription.ToLower());
                    }
                    else
                    {
                        _dbBase.ChangeDatabase(MainDb.CurrentDbConnId.ToLower());
                    }
                }

                return _dbBase;
            }
        }



        public ISqlSugarClient Db
        {
            get { return _db; }
        }
        public async Task<TEntity> QueryById(object objId)
        {
            return await _db.Queryable<TEntity>().InSingleAsync(objId);
            //return await _db.Queryable<TEntity>().In(objId).SingleAsync();
        }
    }
}
