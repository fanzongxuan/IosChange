using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Common.Extension
{
    public static class HttpContextExtension
    {
        public static string GetUserIp(this HttpContext context)
        {
            var ip = "";
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }
    }
}
