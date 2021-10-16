using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Extensions
{
    /// <summary>
    /// 返回统一的业务数据集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageModel<T>
    {
        public PageModel(int pageSize = 20)
        {
            this.ResultList = new List<T>();
            this.PageSize = pageSize;
        }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<T> ResultList { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage
        {
            get
            {
                return TotalRecord % PageSize == 0 ? TotalRecord / PageSize : TotalRecord / PageSize + 1;
            }
        }
    }
}
