using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    public class Comment : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// 账户使用记录
        /// </summary>
       /// public List<CommentsUseRecord> CommentsUseRecords { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
