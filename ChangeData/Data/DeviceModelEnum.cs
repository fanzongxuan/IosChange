using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Change.Data.Data
{
    /// <summary>
    /// 设备机型
    /// </summary>
    public enum DeviceModelEnum
    {
        /// <summary>
        /// iPhone
        /// </summary>
        [Display(Name = "iPhone")]
        iPhone = 0,
        /// <summary>
        /// iPad
        /// </summary>
        [Display(Name = "iPad")]
        iPad = 5,
        /// <summary>
        /// iTouch
        /// </summary>
        [Display(Name = "iTouch")]
        iTouch = 10
    }
}
