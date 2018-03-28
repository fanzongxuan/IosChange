using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    /// <summary>
    /// 改机记录复用记录
    /// </summary>
    public class ReUseRecord : BaseEntity
    {
        /// <summary>
        /// 改机记录（FK）
        /// </summary>
        public int ChangeRecordId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
