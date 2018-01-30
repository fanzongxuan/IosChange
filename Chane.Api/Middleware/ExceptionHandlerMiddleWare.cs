using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Chane.Api.Middleware
{
    /// <summary>
    /// 截获异常
    /// </summary>
    public class ExceptionHandlerMiddleWare
    {

        private readonly RequestDelegate next;
        private readonly ILogger _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public ExceptionHandlerMiddleWare(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this._logger = loggerFactory.CreateLogger("ioschange-api");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            string errorMsg = "";
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                HandleException(context, ex);
            }
            finally
            {
                if (context.Response.StatusCode >= 400 && context.Request != null)
                {
                    context.Response.Redirect($"/errors/{context.Response.StatusCode}?msg={WebUtility.UrlEncode(errorMsg)}");
                }
            }
        }

        private void HandleException(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            WriteException(context, exception);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private void WriteException(HttpContext context, Exception exception)
        {
            //返回友好的提示
            var response = context.Response;

            //状态码
            if (exception is ArgumentException)
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            else if (exception is UnauthorizedAccessException)
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if (exception is NotImplementedException)
                response.StatusCode = (int)HttpStatusCode.NotImplemented;
            else if (exception is NullReferenceException)
                response.StatusCode = (int)HttpStatusCode.NotFound;
            else if (exception is NotSupportedException)
                response.StatusCode = (int)HttpStatusCode.Forbidden;
            else
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (response.StatusCode >= 400)
            {
                //记录日志
                _logger.LogError(0, exception, exception.Message);
            }

        }
    }
}
