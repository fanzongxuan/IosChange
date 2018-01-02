using Change.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Service.Services
{
    public class MachineParamterQuery : PageQuery
    {
        /// <summary>
        /// 原始机器Id
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? FromTime { get; set; }

        /// <summary>
        /// 技术时间
        /// </summary>
        public DateTime? ToTime { get; set; }
    }
}
