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
    /// 改机记录
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class RecordController : Controller
    {

        private readonly IMachineService _machineService;

        /// <summary>
        /// ctor
        /// </summary>
        public RecordController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        /// <summary>
        /// 添加改机记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult AddMahineRecord(AddMachineRecordModel model)
        {
            var changeRecord = new ChangeRecord()
            {
                Name = model.Name,
                UUID = model.UUID,
                AppId = model.AppId,
                Password = model.Password
            };
            _machineService.AddMahineRecord(changeRecord);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 获取改机记录
        /// </summary>
        /// <param name="uuid">uuid</param>
        /// <param name="formateDate">格式化时间(例：20180328)</param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<ChangeRecord> GetChangeRecord(string uuid, string formateDate)
        {
            var res = _machineService.GetChangeRecord(uuid, formateDate);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 添加使用记录
        /// </summary>
        /// <param name="changeRecordId"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult AddUseRecord(int changeRecordId)
        {
            _machineService.AddUseRecord(changeRecordId);
            return ReturnResult.Success();
        }
    }
}