using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Model
{
    public class ChangeRecordModel
    {
        /// <summary>
        /// 唯一主键Id
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
