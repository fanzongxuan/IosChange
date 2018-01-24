using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Change.Data.Data
{
    /// <summary>
    /// 联网类型
    /// </summary>
    public enum NetWorkTypeEnum
    {
        [Display(Name = "2G")]
        SecongGen = 0,
        [Display(Name = "3G")]
        ThirdGen = 5,
        [Display(Name = "4G")]
        FrouthGen = 10,
        [Display(Name = "wifi")]
        Wifi = 15
    }
}
