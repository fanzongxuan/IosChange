using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    public class Machine : BaseEntity
    {
        /// <summary>
        /// IDFV
        /// </summary>
        public string IDFA { get; set; }

        /// <summary>
        /// IDFV
        /// </summary>
        public string IDFV { get; set; }

        /// <summary>
        /// mac 地址
        /// </summary>
        public string MAC { get; set; }

        /// <summary>
        /// 参数列表
        /// </summary>
        public virtual ICollection<MachineParamter> MachineParamters { get; set; } = new List<MachineParamter>();

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
