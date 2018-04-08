using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Change.Common.Core;
using Change.Data.Data;
using Change.Model;
using Change.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chane.Api.Controllers
{
    /// <summary>
    /// 生产管理
    /// </summary>
    public class ProductionRecordController : BaseController
    {
        private readonly IProductionRecordService _productionRecordService;

        /// <summary>
        /// ctor
        /// </summary>
        public ProductionRecordController(IProductionRecordService productionRecordService)
        {
            _productionRecordService = productionRecordService;
        }

        /// <summary>
        /// 根据id获取记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<ProductionRecord> GetById(int id)
        {
            var res = _productionRecordService.GetById(id);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 根据应用包的id获取记录
        /// </summary>
        /// <param name="budleId"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<ProductionRecord> GetByBudleId(string budleId)
        {
            var res = _productionRecordService.GetByBudleId(budleId);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult<ProductionRecord> Insert(AddProductionRecordModel model)
        {
            var entitiy = new ProductionRecord()
            {
                BundleId = model.BundleId,
                AppName = model.AppName
            };
            _productionRecordService.Insert(entitiy);
            return ReturnResult.Success(entitiy);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<bool> Delete(int id)
        {
            _productionRecordService.Delete(id);
            return ReturnResult.Success(true);
        }

        /// <summary>
        /// 添加生产记录
        /// </summary>
        /// <param name="useTimes"></param>
        /// <param name="proRecordId"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult<bool> AddProductionRecord(int useTimes, int proRecordId)
        {
            _productionRecordService.AddUserRecord(useTimes, proRecordId);
            return ReturnResult.Success(true);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<IPagedList<ProductionRecord>> Query(ProductionRecordQuery query)
        {
            var res = _productionRecordService.Query(query);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 每日记录查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<IPagedList<DaliyProduction>> QueryDaliyRecord(DaliyRecordQuery query)
        {
            var res = _productionRecordService.QueryDaliyRecord(query);
            return ReturnResult.Success(res);
        }
    }
}