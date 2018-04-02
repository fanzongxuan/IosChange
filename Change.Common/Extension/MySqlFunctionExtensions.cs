using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Change.Common.Extension
{
    /// <summary>
    /// msqyl 方法扩展
    /// </summary>
    public static class MySqlFunctionExtensions
    {
        [DbFunction("Rand")]
        public static Guid NewId()
        {
            return Guid.NewGuid();
        }

        #region 扩展方法
        /// <summary>
        /// 随机排序扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderByRandom<T>(this IEnumerable<T> source)
        {
            return source.AsQueryable().OrderBy(d => NewId());
        }
        #endregion
    }
}
