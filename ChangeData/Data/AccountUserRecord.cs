using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    /// <summary>
    /// 改机记录复用记录
    /// </summary>
    public class AccountUserRecord : BaseEntity
    {
        /// <summary>
        /// AppStoreAccount Id（FK）
        /// </summary>
        public int AppStoreAccountId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
