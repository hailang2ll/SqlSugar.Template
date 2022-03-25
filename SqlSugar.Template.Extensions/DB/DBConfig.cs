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
        public static List<MutiDBConns> MutiInitConn()
        {
            DBOptions dBOptions = DMS.Common.AppConfig.GetValue<DBOptions>("DBS");
            //if (!dBOptions.MutiDBEnabled)
            //{
            //    //单库模式
            //    if (dBOptions.MutiDBConns.Count == 1)
            //    {
            //        return dBOptions.MutiDBConns;
            //    }
            //    else
            //    {
            //        var dbFirst = dBOptions.MutiDBConns.FirstOrDefault(d => d.ConnId == dBOptions.MainDB);
            //        if (dbFirst == null)
            //        {
            //            dbFirst= dBOptions.MutiDBConns.FirstOrDefault();
            //        }
            //        else
            //        { 
                    
            //        }
            //    }
            //}
            List<MutiDBConns> listdatabase = dBOptions.MutiDBConns.Where(i => i.Enabled).ToList();
            return listdatabase;
        }
    }
}
