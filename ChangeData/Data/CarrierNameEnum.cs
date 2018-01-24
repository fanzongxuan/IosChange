using System.ComponentModel.DataAnnotations;

namespace Change.Data.Data
{
    public enum CarrierNameEnum
    {
        /// <summary>
        /// 中国移动
        /// </summary>
        [Display(Name = "中国移动")]
        ChinaMoblie = 0,
        /// <summary>
        /// 中国联通
        /// </summary>
        [Display(Name = "中国联通")]
        ChinaUnicom = 5,
        /// <summary>
        /// 中国电信
        /// </summary>
        [Display(Name = "中国电信")]
        ChinaTelecom = 10,

    }
}
