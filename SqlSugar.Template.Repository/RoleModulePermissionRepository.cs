using SqlSugar.Template.Models;
using SqlSugar.Template.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Repository
{
    public class RoleModulePermissionRepository : BaseRepository<Sys_JobLog>, IRoleModulePermissionRepository
    {
        public RoleModulePermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
