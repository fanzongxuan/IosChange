using Change.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Service.Services
{
    public class ProductionRecordQuery : PageQuery
    {
        /// <summary>
        /// app 名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 包Id
        /// </summary>
        public string BundleId { get; set; }
    }
}
