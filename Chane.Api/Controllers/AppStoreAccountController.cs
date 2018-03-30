using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Change.Common.Core;
using Change.Data.Data;
using Change.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chane.Api.Controllers
{
    /// <summary>
    /// app store 账号管理
    /// </summary>
    public class AppStoreAccountController : BaseController
    {
        private readonly IAppStoreAccountService _appStoreAccountService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appStoreAccountService"></param>
        public AppStoreAccountController(IAppStoreAccountService appStoreAccountService)
        {
            _appStoreAccountService = appStoreAccountService;
        }

        /// <summary>
        /// 批量添加账号
        /// </summary>
        /// <param name="appStoreAccounts"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult BatchSaveAppStoreAccounts(List<AppStoreAccount> appStoreAccounts)
        {
            _appStoreAccountService.BatchSaveAppStoreAccounts(appStoreAccounts);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult Delete(int id)
        {
            _appStoreAccountService.Delete(id);
            return ReturnResult.Success();
        }

        /// <summary>
        ///根据条件随机获取账号 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="minUseTime"></param>
        /// <param name="maxUseTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<AppStoreAccount> GetRandom(DateTime? startDate, DateTime? endDate, int? minUseTime, int? maxUseTime)
        {
            var res = _appStoreAccountService.GetRandom(startDate, endDate, minUseTime, maxUseTime);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 添加使用记录(若添加该条记录今天将无法再次获取)
        /// </summary>
        /// <param name="appStoreAccountId"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult AddUseRecord(int appStoreAccountId)
        {
            _appStoreAccountService.AddUseRecord(appStoreAccountId);
            return ReturnResult.Success();
        }
    }
}