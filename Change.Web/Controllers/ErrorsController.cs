using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Change.Common.Core;
using Change.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Change.Web.Controllers
{
    public class ErrorsController : BaseController
    {
        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        [Route("errors/{statusCode}")]
        [HttpGet]
        public IActionResult Error(int statusCode, string msg)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            msg = WebUtility.UrlDecode(msg);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            if (HttpContext.Request != null && HttpContext.Request.IsAjaxRequest())
            {
                switch (statusCode)
                {
                   
                    case (int)HttpStatusCode.Unauthorized:
                        return JsonNet(ReturnResult.Failed(string.IsNullOrEmpty(msg) ? "未授权！" : msg, ReturnCode.Unauthorized));
                    case (int)HttpStatusCode.Forbidden:
                        return JsonNet(ReturnResult.Failed(string.IsNullOrEmpty(msg) ? "权限不足！" : msg, ReturnCode.Forbidden));
                    case (int)HttpStatusCode.NotFound:
                        return JsonNet(ReturnResult.Failed(string.IsNullOrEmpty(msg) ? "请求不存在！" : msg, ReturnCode.NotFound));
                    default:
                        return JsonNet(ReturnResult.Failed(string.IsNullOrEmpty(msg) ? "发生错误！" : msg));
                }
            }
            else
            {
                ViewBag.ErrorMsg = msg;
                switch (statusCode)
                {
                    case (int)HttpStatusCode.Forbidden:
                        return View("Error_403");
                    case (int)HttpStatusCode.NotFound:
                        return View("Error_404");
                    default:
                        return View("Error");
                }
            }
        }
    }
}