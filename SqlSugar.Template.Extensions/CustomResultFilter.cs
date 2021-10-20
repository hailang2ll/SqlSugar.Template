using DMSN.Common.BaseResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Template.Extensions
{
    public class CustomResultFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ResponseResult result = new ResponseResult();

                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        result.errmsg += error.ErrorMessage + ",";
                        result.data = "{}";
                    }
                }
                result.errmsg = result.errmsg.TrimEnd(',');
                context.Result = new JsonResult(result);
            }
            else
            {
                var result = context.Result as ObjectResult ?? null;
                context.Result = new OkObjectResult(new ResponseResult
                {
                    errmsg = "成功",
                    data = result == null ? "{}" : result.Value
                });
                base.OnResultExecuting(context);

            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
