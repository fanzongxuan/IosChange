using Change.Data;
using Change.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    public class ProductionRecord : BaseEntity
    {
        /// <summary>
        /// app 名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 应用包Id
        /// </summary>
        public string BundleId { get; set; }

        /// <summary>
        /// 每日生产记录
        /// </summary>
        public IList<DaliyProduction> DailyProductionRecords { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
