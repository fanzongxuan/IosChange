using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Change.Common.Core;
using Change.Data;
using Change.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Change.Service.Services
{
    public class AppStoreAccountService : IAppStoreAccountService
    {

        private readonly ChangeDbContext _dbContext;

        public AppStoreAccountService(ChangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BatchSaveAppStoreAccounts(List<AppStoreAccount> accounts)
        {
            if (accounts == null || accounts.Count == 0)
                throw new ArgumentNullException("app store 账号不能为空！");

            foreach (var account in accounts)
            {
                if (!_dbContext.AppStoreAccount.AsQueryable().Any(x => x.IsDeleted == false && x.AppId == account.AppId))
                {
                    account.CreateTime = DateTime.Now;
                    _dbContext.AppStoreAccount.Add(account);
                }
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id不能为0");
            var entity = _dbContext.AppStoreAccount.AsQueryable().FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
            if (entity == null)
                throw new ArgumentNullException($"不存在id为{id}的app store账号");
            entity.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public AppStoreAccount GetRandom(DateTime? startDate, DateTime? endTime, int? minUseTime, int? maxUseTime)
        {
            var query = _dbContext.AppStoreAccount.AsQueryable().Where(x => x.IsDeleted == false);
            if (startDate.HasValue)
                query = query.Where(x => x.CreateTime >= startDate);
            if (endTime.HasValue)
                query = query.Where(x => x.CreateTime <= endTime);
            if (minUseTime.HasValue)
                query = query.Where(x => x.UseTime <= minUseTime);
            if (maxUseTime.HasValue)
                query = query.Where(x => x.UseTime >= maxUseTime);
            var res = query.FirstOrDefault(x => !x.AccountUserRecords.Any(y => y.IsDeleted == false && y.CreateTime.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd")));
            return res;
        }

        public void AddUseRecord(int appStoreAccountId)
        {
            if (appStoreAccountId == 0)
                throw new ArgumentNullException("appStoreAccountId不能为0");

            var account = _dbContext.AppStoreAccount.FirstOrDefault(x => x.IsDeleted == false && x.Id == appStoreAccountId);
            if (account == null)
                throw new ArgumentNullException("该账户不存在！");

            account.UseTime += 1;

            var entity = new AccountUserRecord()
            {
                AppStoreAccountId = appStoreAccountId,
                IsDeleted = false,
                CreateTime = DateTime.Now
            };
            _dbContext.AccountUserRecord.Add(entity);
            _dbContext.SaveChanges();
        }

        public IPagedList<AppStoreAccount> QueryAccount(AccountQuery query)
        {
            var queryable = _dbContext.AppStoreAccount.AsQueryable().Where(x => x.IsDeleted == false);

            if (!string.IsNullOrEmpty(query.AppId))
                queryable = queryable.Where(x => x.AppId.Contains(query.AppId));
            return new PagedList<AppStoreAccount>(queryable, query.PageIndex, query.PageSize);
        }
    }
}
