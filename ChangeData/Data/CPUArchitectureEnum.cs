using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Change.Data.Data
{
    public enum CPUArchitectureEnum
    {
        /// <summary>
        /// arm64
        /// </summary>
        [Display(Name = "arm64")]
        arm64 =0,

        /// <summary>
        /// armv7
        /// </summary>
        [Display(Name = "armv7")]
        armv7 = 5,

        /// <summary>
        /// armv7s
        /// </summary>
        [Display(Name = "armv7s")]
        armv7s =10
    }
}
