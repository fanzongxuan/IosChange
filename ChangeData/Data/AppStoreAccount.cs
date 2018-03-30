using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    public class AppStoreAccount : BaseEntity
    {
        /// <summary>
        /// appid
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 总使用次数
        /// </summary>
        public int UseTime { get; set; }

        /// <summary>
        /// 账户使用记录
        /// </summary>
        public List<AccountUserRecord> AccountUserRecords { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
