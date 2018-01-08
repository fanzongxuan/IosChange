using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Change.Common.Core;
using Microsoft.AspNetCore.Mvc;

namespace Chane.Api.Controllers
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public class ErrorController : BaseController
    {
        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        [Route("errors/{statusCode}")]
        [HttpGet]
        public ReturnResult Error(int statusCode, string msg)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            switch (statusCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    return ReturnResult.Failed("未授权！", ReturnCode.Unauthorized);
                case (int)HttpStatusCode.Forbidden:
                    return ReturnResult.Failed("权限不足！", ReturnCode.Forbidden);
                case (int)HttpStatusCode.NotFound:
                    return ReturnResult.Failed("请求不存在！", ReturnCode.NotFound);
                default:
                    if (!string.IsNullOrEmpty(msg))
                    {
                        return ReturnResult.Failed(WebUtility.UrlDecode(msg));
                    }
                    return ReturnResult.Failed("发生错误！");
            }
        }
    }
}