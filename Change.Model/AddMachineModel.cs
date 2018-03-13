using System;
using System.ComponentModel.DataAnnotations;

namespace Change.Model
{
    public class AddMachineModel
    {
        /// <summary>
        /// UUID
        /// </summary
        [Required]
        public string Ip { get; set; }

        /// <summary>
        /// 包名
        /// </summary>
        public string BudleId { get; set; }
    }
}
