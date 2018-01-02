using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Common.Core
{
    public class PageQuery
    {
        /// <summary>
        /// 索引(默认0)
        /// </summary>
        public virtual int PageIndex { get; set; }

        /// <summary>
        /// 页码大小(默认10)
        /// </summary>
        public virtual int PageSize { get; set; }

        public PageQuery()
        {
            this.PageIndex = 0;
            this.PageSize = 10;
        }
    }
}
