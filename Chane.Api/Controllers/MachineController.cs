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
        /// 根据UUID获取设备
        /// </summary>
        /// <param name="mac"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult<Machine> GetMachineByIP(string mac)
        {
            var res = _machineService.GetMachineByIP(mac);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 不存在即新增设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult<MachineParamter> GetInUseParam([FromBody]AddMachineModel model)
        {
            var entity = new Machine()
            {
                Ip = model.Ip
            };

            var machine = _machineService.AddMachineIfNotExist(entity);
            var res = _machineService.GetInUseMachineParamter(machine.Id, model.BudleId);
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
                Ip = model.Ip
            };
            var machine = _machineService.AddMachineIfNotExist(entity);

            //获取自定义参数
            var res = _machineService.GetInUseMachineParamter(machine.Id, model.BudleId).ToModel();

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

        /// <summary>
        /// 一键新机
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult NewMachine()
        {
            string ip = Request.HttpContext.GetUserIp();
            var machine = _machineService.GetMachineByIP(ip);
            var res = _machineService.GenerateMachineParamter(machine.Id);
            _machineService.SetMachineParamterEnable(machine.Id, true);
            return ReturnResult.Success(res);
        }

        /// <summary>
        /// 添加作用包名
        /// </summary>
        /// <param name="budleIds"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnResult AddImpactBudleIds(List<string> budleIds)
        {
            string ip = Request.HttpContext.GetUserIp();
            var machine = _machineService.GetMachineByIP(ip);
            _machineService.AddImpactBudleIds(budleIds, machine.Id);
            return ReturnResult.Success();
        }

        /// <summary>
        /// 删除作用包名
        /// </summary>
        /// <param name="budleIds"></param>
        /// <returns></returns>
        [HttpGet]
        public ReturnResult DeleteImpactBudleIds(List<string> budleIds)
        {
            string ip = Request.HttpContext.GetUserIp();
            var machine = _machineService.GetMachineByIP(ip);
            _machineService.DeleteBudleIds(budleIds, machine.Id);
            return ReturnResult.Success();
        }

        #endregion
    }
}