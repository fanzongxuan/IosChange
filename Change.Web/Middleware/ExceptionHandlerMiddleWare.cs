using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Change.Web.Middleware
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleWare(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this._logger = loggerFactory.CreateLogger("perfay-web");
        }

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
                await HandleExceptionAsync(context, ex);
            }
            finally
            {
                if (context.Response.StatusCode >= 400 && context.Request != null)
                {
                    context.Response.Redirect($"/errors/{context.Response.StatusCode}?msg={WebUtility.UrlEncode(errorMsg)}");
                }
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }

        private async Task WriteExceptionAsync(HttpContext context, Exception exception)
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
            else if (exception is ArgumentNullException)
                response.StatusCode = (int)HttpStatusCode.NotFound;
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
