using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    public class ChangeRecord : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机UUID
        /// </summary>
        public string UUID { get; set; }

        /// <summary>
        /// ios apple id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 使用记录
        /// </summary>
        public virtual ICollection<ReUseRecord> ReUseRecords { get; set; } = new List<ReUseRecord>();
    }
}
