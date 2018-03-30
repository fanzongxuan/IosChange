using Change.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Service.Services
{
    /// <summary>
    /// 账户查询
    /// </summary>
    public class AccountQuery : PageQuery
    {
        /// <summary>
        /// Appid
        /// </summary>
        public string AppId { get; set; }
    }
}
