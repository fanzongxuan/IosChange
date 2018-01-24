using System.Collections;
using System.Collections.Generic;

namespace Change.Common.Core
{
    public class DataSourceResult<T> : DataSourceResult
    {
        public new IEnumerable<T> rows { get; set; }
    }

    public class DataSourceResult
    {
        public IEnumerable rows { get; set; }

        public int total { get; set; }
    }
}
