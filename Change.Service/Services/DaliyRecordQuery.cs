using Change.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Service.Services
{
    public class DaliyRecordQuery : PageQuery
    {
        /// <summary>
        /// 记录id
        /// </summary>
        public int? ProductionRecordId { get; set; }

        /// <summary>
        /// 使用次数
        /// </summary>
        public int? Times { get; set; }
    }
}
