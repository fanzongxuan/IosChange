using Change.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Service.Services
{
    public class MachineQuery : PageQuery
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? FromTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? ToTime { get; set; }
    }
}
