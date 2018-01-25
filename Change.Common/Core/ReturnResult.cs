using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Common.Core
{
    public class ReturnResult
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public static ReturnResult Success()
        {
            return new ReturnResult
            {
                Code = (int)ReturnCode.Sucess
            };
        }

        public static ReturnResult<T> Success<T>(T result, string message = null)
        {
            return new ReturnResult<T>
            {
                Code = (int)ReturnCode.Sucess,
                Result = result,
                Message = message
            };
        }

        public static ReturnResult Failed(Exception exception, ReturnCode code = ReturnCode.Error)
        {
            return new ReturnResult
            {
                Code = (int)code,
                Message = exception.Message
            };
        }

        public static ReturnResult Failed(string msg, ReturnCode code = ReturnCode.Error)
        {
            return new ReturnResult
            {
                Code = (int)code,
                Message = msg
            };
        }
    }
    public class ReturnResult<T> : ReturnResult
    {
        public T Result { get; set; }
    }
}
