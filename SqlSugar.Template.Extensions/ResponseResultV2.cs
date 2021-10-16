using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Extensions
{
    /// <summary>
    ///  请求响应结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseResultV2<T> : ResponseResultV2
    {


    }

    public class ResponseResultV2
    {
        /// <summary>
        /// 状态，0=成功，非0失败
        /// </summary>
        public int errno { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 扩展字段1
        /// </summary>
        public object ext1 { get; set; }

        public ResponseResultV2()
        {
            errno = 0;//默认为0
            errmsg = "";
            data = new object();
            ext1 = new object();
        }
    }
}
