using System;
using System.ComponentModel.DataAnnotations;

namespace Change.Model
{
    public class AddMachineModel
    {
        /// <summary>
        /// IDFV
        /// </summary>
        [Required]
        public string IDFA { get; set; }

        /// <summary>
        /// IDFV
        /// </summary>
        [Required]
        public string IDFV { get; set; }

        /// <summary>
        /// mac 地址
        /// </summary
        [Required]
        public string MAC { get; set; }

    }
}
