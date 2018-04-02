using Change.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Service.Services
{
    /// <summary>
    /// 评论查询
    /// </summary>
    public class CommentQuery : PageQuery
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
    }
}
