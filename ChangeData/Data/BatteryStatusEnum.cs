using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Change.Data.Data
{
    public enum BatteryStatusEnum
    {
        /// <summary>
        /// 无法获取
        /// </summary>
        [Display(Name = "无法取得充电状态")]
        UnAvailability = 0,
        /// <summary>
        /// 非充电状态
        /// </summary>
        [Display(Name = "非充电状态")]
        NoCharge = 1,
        /// <summary>
        /// 充电状态
        /// </summary>
        [Display(Name = "充电状态")]
        Charging = 2,
        /// <summary>
        /// 充满状态
        /// </summary>
        [Display(Name = "充满状态")]
        Full = 3

    }
}
