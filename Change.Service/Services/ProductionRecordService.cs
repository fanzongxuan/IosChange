using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Change.Common.Core;
using Change.Data;
using Change.Data.Data;

namespace Change.Service.Services
{
    public class ProductionRecordService : IProductionRecordService
    {
        private readonly ChangeDbContext _dbContext;

        public ProductionRecordService(ChangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUserRecord(int useTimes, int proRecordId)
        {
            //1.0 是否存在对应的记录
            var production = _dbContext.ProductionRecord.AsQueryable().FirstOrDefault(x => x.IsDeleted == false && x.Id == proRecordId);

            if (production == null)
                throw new ArgumentNullException($"不存在记录Id为{proRecordId}的记录");

            //2.0 查找当天记录是否存在,存在使用次数累加，不存在新增
            var productionRecord = _dbContext.DailyProductionRecord.AsQueryable().
                FirstOrDefault(x => x.IsDeleted == false && x.ProductionRecordId == proRecordId && x.CreateTime.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"));

            if (productionRecord == null)
            {
                var dailyRecord = new DaliyProduction()
                {
                    ProductionRecordId = proRecordId,
                    Times = useTimes,
                    CreateTime = DateTime.Now
                };
                InsertDaliyProductionRecord(dailyRecord);
            }
            else
            {
                productionRecord.Times += useTimes;
                _dbContext.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("id 不能为0");
            var entity = _dbContext.ProductionRecord.AsQueryable().FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
            if (entity == null)
                throw new ArgumentNullException($"不存在id为{id}的记录");

            entity.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public void DeleteDaliyRecord(int id)
        {
            if (id == 0)
                throw new ArgumentException("id不能为0");

            var record = _dbContext.DailyProductionRecord.AsQueryable().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (record == null)
                throw new ArgumentNullException("record不能为空");
            record.IsDeleted = false;
            _dbContext.SaveChanges();
        }

        public ProductionRecord GetById(int id)
        {
            if (id == 0)
                throw new ArgumentException("id不能为0");
            var entitiy = _dbContext.ProductionRecord.AsQueryable().FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
            return entitiy;
        }

        public void Insert(ProductionRecord entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entitiy不能为空");

            entity.CreateTime = DateTime.Now;
            _dbContext.ProductionRecord.Add(entity);
            _dbContext.SaveChanges();
        }

        public IPagedList<ProductionRecord> Query(ProductionRecordQuery qeury)
        {
            var qeuryable = _dbContext.ProductionRecord.AsQueryable().Where(x => x.IsDeleted == false);
            if (!string.IsNullOrWhiteSpace(qeury.AppName))
                qeuryable = qeuryable.Where(x => x.AppName.Contains(qeury.AppName));
            if (!string.IsNullOrWhiteSpace(qeury.BundleId))
                qeuryable = qeuryable.Where(x => x.BundleId.Contains(qeury.BundleId));
            var result = new PagedList<ProductionRecord>(qeuryable, qeury.PageIndex, qeury.PageSize);
            return result;
        }

        public IPagedList<DaliyProduction> QueryDaliyRecord(DaliyRecordQuery query)
        {
            var queryable = _dbContext.DailyProductionRecord.AsQueryable().Where(x => x.IsDeleted == false);
            if (query.ProductionRecordId.HasValue)
                queryable = queryable.Where(x => x.ProductionRecordId == query.ProductionRecordId);
            if (query.Times.HasValue)
                queryable = queryable.Where(x => x.Times == query.Times);
            var result = new PagedList<DaliyProduction>(queryable, query.PageIndex, query.PageSize);
            return result;
        }

        public DaliyProduction InsertDaliyProductionRecord(DaliyProduction entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity 不能为空");

            entity.CreateTime = DateTime.Now;
            _dbContext.DailyProductionRecord.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public ProductionRecord GetByBudleId(string budleId)
        {
            if (string.IsNullOrWhiteSpace(budleId))
                throw new ArgumentNullException("budleId不能为空");
            var entity = _dbContext.ProductionRecord.AsQueryable().FirstOrDefault(x => x.IsDeleted == false && x.BundleId == budleId);
            return entity;
        }
    }
}
