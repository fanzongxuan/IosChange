using System;
using System.Collections.Generic;
using System.Text;

namespace Change.Data.Data
{
    public class MachineParamter : BaseEntity
    {

        /// <summary>
        /// 设备Id（FK）
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// sample :kCTWirelessTechnologyUnkonwn
        /// </summary>
        public string ActiveWirelessTechnology { get; set; }

        /// <summary>
        /// Wifi 商户 sample:Murata
        /// </summary>
        public string WifiVendor { get; set; }

        /// <summary>
        /// Sample:LL/A
        /// </summary>
        public string RegionInfo { get; set; }

        /// <summary>
        /// LL
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// sampale:12.2.2
        /// </summary>
        public string MinimumSupportediTunesVersion { get; set; }

        /// <summary>
        /// sample:iBoot-2817.20.26
        /// </summary>
        public string FirewareVersion { get; set; }

        /// <summary>
        /// 系统版本 sample:9.2.1
        /// </summary>
        public string ProductVersion { get; set; }

        /// <summary>
        /// 设备详细型号，sample:iPhone 5,3
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// sample:Iphone OS
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// sample:13D15
        /// </summary>
        public string BuildVersion { get; set; }

        /// <summary>
        ///sample: iPhone
        /// </summary>
        public string DeviceClass { get; set; }

        /// <summary>
        /// sapmple:#ele4e3
        /// </summary>
        public string DeviceColor { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        public DeviceModelEnum DeviceName { get; set; }

        /// <summary>
        /// sample:t700
        /// </summary>
        public string HardwarePlatform { get; set; }

        /// <summary>
        /// sample:N61AP
        /// </summary>
        public string HWModelStr { get; set; }

        /// <summary>
        /// sample:A
        /// </summary>
        public string DeviceVariant { get; set; }

        /// <summary>
        /// cpu 架构
        /// </summary>
        public CPUArchitectureEnum CPUArchitecture { get; set; }

        /// <summary>
        /// 用户自定义设备名称
        /// </summary>
        public string UserAssignedDeviceName { get; set; }

        /// <summary>
        /// UUID
        /// </summary>
        public string UniqueDeviceId { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// sample:MG502
        /// </summary>
        public string ModelNumber { get; set; }

        /// <summary>
        /// 是否使用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

    }
}
