using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugar.Template.Extensions.DB
{
    public class DBConfig
    {
        /// <summary>
        /// 多库连接
        /// </summary>
        /// <returns></returns>
        public static List<DBOptions> MutiInitConn()
        {
            List<DBOptions> listdatabase = DMS.Common.AppConfig.GetValueList<DBOptions>("DBS")
                   .Where(i => i.Enabled).ToList();
            return listdatabase;
        }
    }
}
