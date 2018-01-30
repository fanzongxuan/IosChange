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
    /// 改机
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class MachineController : BaseController
    {
        private readonly IMachineService _machineService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="machineService"></param>
        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        #region Machine
        /// <summary>
        /// 根据mac地址获取设备
        /// </summary>
        /// <param name="mac"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<Machine> GetMachineByMac(string mac)
        {
            var res = _machineService.GetMachineByMac(mac);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 不存在即新增设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult<Machine> AddMachineIfNotExist([FromBody]AddMachineModel model)
        {
            var entity = new Machine()
            {
                IDFA = model.IDFA,
                IDFV = model.IDFV,
                MAC = model.MAC
            };

            var res = _machineService.AddMachineIfNotExist(entity);
            return ReturnResult.Success(res);
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

        /// <summary>
        /// 修改设备信息(不修改关联的改机参数)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult UpdateMachine([FromBody]Machine model)
        {
            var res = _machineService.UpdateMachine(model);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 设备查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<IPagedList<Machine>> MachineQuery([FromQuery]MachineQuery query)
        {
            var res = _machineService.MachineQuery(query);
            return ReturnResult.Success(res);
        }
        #endregion

        #region MachineParamters

        /// <summary>
        /// 添加设备的改机记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult<MachineParamter> AddMachineParamters(AddMachineParamterModel model)
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
            var res = _machineService.AddMachineParamters(entity);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 获取正在使用的改机记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult<MachineParamterModel> GetInUseMachineParamter([FromBody]AddMachineModel model)
        {
            //如果设备不存在就增加
            var entity = new Machine()
            {
                IDFA = model.IDFA,
                IDFV = model.IDFV,
                MAC = model.MAC
            };
            var machine = _machineService.AddMachineIfNotExist(entity);

            //获取自定义参数
            var res = _machineService.GetInUseMachineParamter(machine.Id).ToModel();
            
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 生成改机参数并启用
        /// </summary>
        /// <param name="machineId">设备id</param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult GenerateMachineParamter(int machineId)
        {
            var res = _machineService.GenerateMachineParamter(machineId);
            _machineService.SetMachineParamterEnable(res.Id, true);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 删除设备改机参数记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult DeleteMachineParamter(int id)
        {
            _machineService.DeleteMachineParamter(id);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 设备改机记录查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<IPagedList<MachineParamter>> MachineParamterQuery([FromQuery]MachineParamterQuery query)
        {
            var res = _machineService.MachineParamterQuery(query);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 启用设备参数记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult SetMachineParamterEnable(int id)
        {
            _machineService.SetMachineParamterEnable(id, true);
            return ReturnResult.Success();
        }

        #endregion
    }
}