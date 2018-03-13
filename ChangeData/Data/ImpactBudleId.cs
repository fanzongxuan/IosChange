using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    /// <summary>
    /// 作用的包名
    /// </summary>
    public class ImpactBudleId: BaseEntity
    {

        /// <summary>
        /// 设备Id（FK）
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// 包名
        /// </summary>
        public string BudleId { get; set; }
    }
}
