using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Model
{
    /// <summary>
    /// 添加改机记录
    /// </summary>
    public class AddMachineRecordModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机UUID
        /// </summary>
        public string UUID { get; set; }

        /// <summary>
        /// ios apple id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
