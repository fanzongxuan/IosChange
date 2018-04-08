using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    public class DaliyProduction : BaseEntity
    {
        /// <summary>
        /// 生产记录Id(FK)
        /// </summary>
        public int ProductionRecordId { get; set; }

        /// <summary>
        /// 目标量
        /// </summary>
        public int TargetTimes { get; set; }

        /// <summary>
        /// 生产量
        /// </summary>
        public int Times { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
