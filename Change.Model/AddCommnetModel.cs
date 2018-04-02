using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Model
{
    /// <summary>
    /// 新增评论model
    /// </summary>
    public class AddCommentModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
