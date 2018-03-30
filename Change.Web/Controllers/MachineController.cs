using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Change.Common.Core;
using Change.Common.Extension;
using Change.Data.Data;
using Change.Model;
using Change.Service.Services;
using Microsoft.AspNetCore.Http;
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
                        x.ActiveWirelessTechnology,
                        x.WifiVendor,
                        x.RegionCode,
                        x.RegionInfo,
                        x.MinimumSupportediTunesVersion,
                        x.FirewareVersion,
                        x.ProductVersion,
                        x.ProductType,
                        x.ProductName,
                        x.BuildVersion,
                        x.DeviceClass,
                        x.DeviceColor,
                        x.DeviceName,
                        x.HardwarePlatform,
                        x.HWModelStr,
                        x.DeviceVariant,
                        CPUArchitecture = x.CPUArchitecture.GetName(),
                        x.UserAssignedDeviceName,
                        x.UniqueDeviceId,
                        x.SerialNumber,
                        x.ModelNumber,
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
                    ActiveWirelessTechnology = model.ActiveWirelessTechnology,
                    WifiVendor = model.WifiVendor,
                    RegionCode = model.RegionCode,
                    RegionInfo = model.RegionInfo,
                    MinimumSupportediTunesVersion = model.MinimumSupportediTunesVersion,
                    FirewareVersion = model.FirewareVersion,
                    ProductVersion = model.ProductVersion,
                    ProductType = model.ProductType,
                    ProductName = model.ProductName,
                    BuildVersion = model.BuildVersion,
                    DeviceClass = model.DeviceClass,
                    DeviceColor = model.DeviceColor,
                    DeviceName = model.DeviceName,
                    HardwarePlatform = model.HardwarePlatform,
                    HWModelStr = model.HWModelStr,
                    DeviceVariant = model.DeviceVariant,
                    CPUArchitecture = model.CPUArchitecture,
                    UserAssignedDeviceName = model.UserAssignedDeviceName,
                    UniqueDeviceId = model.UniqueDeviceId,
                    SerialNumber = model.SerialNumber,
                    ModelNumber = model.ModelNumber,
                };
                _machineService.AddMachineParamters(entity);

                if (model.Enable)
                    _machineService.SetMachineParamterEnable(entity.Id, true);

                return RedirectToAction("DetailParam", new { id = entity.Id });

            }
            else
            {
                var errors = string.Join(';', ModelState.Errors());
                ErrorNotification(errors);
                return View(model);
            }

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