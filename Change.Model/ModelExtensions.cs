using Change.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Model
{
    public static class ModelExtensions
    {
        public static MachineParamterModel ToModel(this MachineParamter entity)
        {
            var model = new MachineParamterModel()
            {
                Id = entity.Id,
                ActiveWirelessTechnology = entity.ActiveWirelessTechnology,
                WifiVendor = entity.WifiVendor,
                RegionCode = entity.RegionCode,
                RegionInfo = entity.RegionInfo,
                MinimumSupportediTunesVersion = entity.MinimumSupportediTunesVersion,
                FirewareVersion = entity.FirewareVersion,
                ProductVersion = entity.ProductVersion,
                ProductType = entity.ProductType,
                ProductName = entity.ProductName,
                BuildVersion = entity.BuildVersion,
                DeviceClass = entity.DeviceClass,
                DeviceColor = entity.DeviceColor,
                DeviceName = entity.DeviceName,
                HardwarePlatform = entity.HardwarePlatform,
                HWModelStr = entity.HWModelStr,
                DeviceVariant = entity.DeviceVariant,
                CPUArchitecture = entity.CPUArchitecture,
                UserAssignedDeviceName = entity.UserAssignedDeviceName,
                UniqueDeviceId = entity.UniqueDeviceId,
                SerialNumber = entity.SerialNumber,
                ModelNumber = entity.ModelNumber,
                Enable = entity.Enable,
                CreateTime = entity.CreateTime,
                UpdateTime = entity.UpdateTime
            };
            return model;
        }
    }
}
