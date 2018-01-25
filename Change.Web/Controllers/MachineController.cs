using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Change.Common.Core;
using Change.Common.Extension;
using Change.Data.Data;
using Change.Model;
using Change.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Change.Web.Controllers
{
    /// <summary>
    /// 设备管理
    /// </summary>
    public class MachineController : BaseController
    {
        #region Fileds

        private readonly IMachineService _machineService;
        #endregion

        #region Ctor

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }
        #endregion

        #region Methods

        #region List

        /// <summary>
        /// 设备列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 设备列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ListJson([FromBody]MachineQuery query)
        {
            var res = _machineService.MachineQuery(query);
            var result = new DataSourceResult()
            {
                rows = res,
                total = res.Count
            };
            return JsonNet(result);
        }


        #endregion


        /// <summary>
        /// 启用自定义参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult EnableMachine(int id, bool enable)
        {
            _machineService.SetMachineEnable(id, enable);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult DeleteMachine(int id)
        {
            _machineService.DeleteMachine(id);
            return ReturnResult.Success();
        }

        #region ParamList

        /// <summary>
        /// 设备改机参数列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ParamList(int machineId)
        {
            ViewBag.MachineId = machineId;
            return View();
        }

        /// <summary>
        /// 设备改机参数列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ParamListJson([FromBody]MachineParamterQuery query)
        {
            var res = _machineService.MachineParamterQuery(query);
            var result = new DataSourceResult()
            {
                rows = res.Select(x =>
                {
                    return new
                    {
                        x.Id,
                        x.Name,
                        x.LocalName,
                        x.SystemName,
                        DeviceModelName = x.DeviceModel.GetName(),
                        x.UUID,
                        x.IDFV,
                        x.SystemVersion,
                        x.IDFA,
                        x.MAC,
                        x.Type,
                        x.Resolution,
                        x.ResolutionZoom,
                        CarrierName = x.CarrierName.GetName(),
                        BatteryStatusName = x.BatteryStatus.GetName(),
                        x.BatteryLevel,
                        x.MachineTag,
                        x.ScreenBrightness,
                        x.WifiName,
                        NetWorkTypeName = x.NetWorkType.GetName(),
                        x.LocalLanguage,
                        x.IMEI,
                        x.SaleArea,
                        x.Enable,
                        x.CreateTime,
                        x.UpdateTime
                    };
                }),
                total = res.Count
            };
            return JsonNet(result);
        }
        #endregion


        /// <summary>
        /// 启用自定义参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult EnableMachineParam(int id, bool enable)
        {
            _machineService.SetMachineParamterEnable(id, enable);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 创建机器自定义参数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateParam(int machineId)
        {
            var model = new AddMachineParamterModel();
            model.MachineId = machineId;
            return View(model);
        }

        /// <summary>
        /// 创建机器自定义参数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="enable">是否启用</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateParam(AddMachineParamterModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new MachineParamter()
                {
                    MachineId = model.MachineId,
                    Name = model.Name,
                    LocalName = model.LocalName,
                    SystemName = model.SystemName,
                    UUID = model.UUID,
                    IDFV = model.IDFV,
                    SystemVersion = model.SystemVersion,
                    IDFA = model.IDFA,
                    MAC = model.MAC,
                    Type = model.Type,
                    Resolution = model.Resolution,
                    ResolutionZoom = model.ResolutionZoom,
                    CarrierName = model.CarrierName,
                    DeviceModel = model.DeviceModel,
                    BatteryStatus = model.BatteryStatus,
                    BatteryLevel = model.BatteryLevel,
                    MachineTag = model.MachineTag,
                    ScreenBrightness = model.ScreenBrightness,
                    WifiName = model.WifiName,
                    NetWorkType = model.NetWorkType,
                    LocalLanguage = model.LocalLanguage,
                    IMEI = model.IMEI,
                    SaleArea = model.SaleArea
                };
                _machineService.AddMachineParamters(entity);

                if (model.Enable)
                    _machineService.SetMachineParamterEnable(entity.Id, true);

            }
            else
            {
                var errors = string.Join(';', ModelState.Errors());
                ErrorNotification(errors);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DetailParam(int id)
        {
            var model = _machineService.GetMachineParamterById(id).ToModel();
            return View(model);
        }

        /// <summary>
        /// 删除参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult DeleteParam(int id)
        {
            _machineService.DeleteMachineParamter(id);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 快速生成自定义参数并启用
        /// </summary>
        /// <param name="machineId">设备Id</param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult QuickGenerate(int machineId)
        {
            var entity = _machineService.GenerateMachineParamter(machineId);
            _machineService.SetMachineParamterEnable(entity.Id, true);
            return ReturnResult.Success();
        }

        #endregion
    }
}