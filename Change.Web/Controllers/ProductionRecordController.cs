using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Change.Common.Core;
using Change.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Change.Web.Controllers
{
    public class ProductionRecordController : BaseController
    {
        private readonly IProductionRecordService _productionRecordService;

        public ProductionRecordController(IProductionRecordService productionRecordService)
        {
            _productionRecordService = productionRecordService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ListJson([FromBody]ProductionRecordQuery query)
        {
            var res = _productionRecordService.Query(query);
            var result = new DataSourceResult()
            {
                rows = res,
                total = res.TotalCount
            };
            return JsonNet(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult Delete(int id)
        {
            _productionRecordService.Delete(id);
            return ReturnResult.Success();
        }

        [HttpGet]
        public IActionResult DaliyRecordList(int productionRecordId)
        {
            ViewBag.ProductionRecordId = productionRecordId;
            return View();
        }

        [HttpPost]
        public IActionResult DaliyRecordListJosn([FromBody]DaliyRecordQuery query)
        {
            var res = _productionRecordService.QueryDaliyRecord(query);
            var result = new DataSourceResult()
            {
                rows = res,
                total = res.TotalCount
            };
            return JsonNet(result);
        }

        [HttpGet]
        public ReturnResult DaliyRecordDelete(int id)
        {
            _productionRecordService.Delete(id);
            return ReturnResult.Success();
        }

    }
}