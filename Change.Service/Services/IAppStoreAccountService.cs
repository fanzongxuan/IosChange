using Change.Common.Core;
using Change.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Service.Services
{
    public interface IAppStoreAccountService
    {
        /// <summary>
        /// 批量保存app store账号
        /// </summary>
        /// <param name="accounts"></param>
        void BatchSaveAppStoreAccounts(List<AppStoreAccount> accounts);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 随机获取账号
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="useTime">使用次数</param>
        /// <returns></returns>
        AppStoreAccount GetRandom(DateTime? startDate, DateTime? endDate, int? minUseTime, int? maxUseTime);

        /// <summary>
        /// 添加使用记录
        /// </summary>
        void AddUseRecord(int appStoreAccountId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IPagedList<AppStoreAccount> QueryAccount(AccountQuery query);

        /// <summary>
        /// 记录回滚
        /// </summary>
        /// <param name="id"></param>
        void RollBack(int id);

    }
}
