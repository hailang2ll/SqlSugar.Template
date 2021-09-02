using SqlSugar.Template.Contracts;
using SqlSugar.Template.Models;
using SqlSugar.Template.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Service
{
    public class SysJobLogService : BaseServices<Sys_JobLog>, ISysJobLogService
    {

        private readonly IBaseRepository<Sys_JobLog> _dal;
        public SysJobLogService(IBaseRepository<Sys_JobLog> dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

        public Task<string> GetUserRoleNameStr(string loginName, string loginPwd)
        {
            throw new NotImplementedException();
        }

        public Task<Sys_JobLog> SaveUserInfo(string loginName, string loginPwd)
        {
            throw new NotImplementedException();
        }
    }
}
