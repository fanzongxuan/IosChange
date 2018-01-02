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
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        ///// <summary>
        ///// 设备名称
        ///// </summary>
        //public string Name { get; set; }

        ///// <summary>
        ///// 设备本地名称
        ///// </summary>
        //public string LocalName { get; set; }

        ///// <summary>
        ///// 设备系统名称
        ///// </summary>
        //public string SystemName { get; set; }

        ///// <summary>
        ///// UUID
        ///// </summary>
        //public string UUID { get; set; }

        ///// <summary>
        ///// IDFV
        ///// </summary>
        //public string IDFV { get; set; }

        ///// <summary>
        ///// 系统版本
        ///// </summary>
        //public string SystemVersion { get; set; }

    }
}
