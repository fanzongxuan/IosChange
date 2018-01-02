using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Common.Core
{
    public enum ReturnCode
    {
        Error = -1,
        Sucess = 1,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404
    }
}
