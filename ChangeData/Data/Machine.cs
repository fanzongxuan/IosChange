using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    public class Machine : BaseEntity
    {
        /// <summary>
        ///Ip
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 是否启用自定义参数
        /// </summary>
        public bool EnableMachineParaters { get; set; }

        /// <summary>
        /// 参数列表
        /// </summary>
        public virtual ICollection<MachineParamter> MachineParamters { get; set; } = new List<MachineParamter>();

        /// <summary>
        /// 参数列表
        /// </summary>
        public virtual ICollection<ImpactBudleId> ImpactBudleIds { get; set; } = new List<ImpactBudleId>();

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
