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
                MachineId = entity.MachineId,
                Name = entity.Name,
                LocalName = entity.LocalName,
                SystemName = entity.SystemName,
                DeviceModel = entity.DeviceModel,
                UUID = entity.UUID,
                IDFV = entity.IDFV,
                IDFA = entity.IDFA,
                SystemVersion = entity.SystemVersion,
                MAC = entity.MAC,
                Type = entity.Type,
                Resolution = entity.Resolution,
                ResolutionZoom = entity.ResolutionZoom,
                CarrierName = entity.CarrierName,
                BatteryStatus = entity.BatteryStatus,
                BatteryLevel = entity.BatteryLevel,
                MachineTag = entity.MachineTag,
                ScreenBrightness = entity.ScreenBrightness,
                WifiName = entity.WifiName,
                NetWorkType = entity.NetWorkType,
                LocalLanguage = entity.LocalLanguage,
                IMEI = entity.IMEI,
                SaleArea = entity.SaleArea,
                Enable = entity.Enable,
                CreateTime = entity.CreateTime,
                UpdateTime = entity.UpdateTime
            };
            return model;
        }
    }
}
