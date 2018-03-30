using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chane.Api.Controllers
{
    /// <summary>
    /// 基控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!ModelState.IsValid)
            {
                context.Result = BadRequest(new
                {
                    Code = 400,
                    Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList(),
                    Message = "请求包含不符合规范的参数"
                });
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}