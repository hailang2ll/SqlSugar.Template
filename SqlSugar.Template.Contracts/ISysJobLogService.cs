using SqlSugar.Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Contracts
{
    /// <summary>
    /// 
    /// </summary>	
    public interface ISysJobLogService : IBaseServices<Sys_JobLog>
    {
        Task<Sys_JobLog> SaveUserInfo(string loginName, string loginPwd);
        Task<string> GetUserRoleNameStr(string loginName, string loginPwd);
    }
}
