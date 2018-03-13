using Change.Common.Extension;
using Change.Data.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Change.Model
{
    public class MachineParamterModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 设备Id（FK）
        /// </summary>
        public int MachineId { get; set; }


        /// <summary>
        /// sample :kCTWirelessTechnologyUnkonwn
        /// </summary>
        [Display(Name = "ActiveWirelessTechnology")]
        public string ActiveWirelessTechnology { get; set; }

        /// <summary>
        /// Wifi 商户 sample:Murata
        /// </summary>
        [Display(Name = "Wifi商户")]
        public string WifiVendor { get; set; }

        /// <summary>
        /// Sample:LL/A
        /// </summary>
        [Display(Name = "区域信息")]
        public string RegionInfo { get; set; }

        /// <summary>
        /// LL
        /// </summary>
        [Display(Name = "区域代码")]
        public string RegionCode { get; set; }

        /// <summary>
        /// sampale:12.2.2
        /// </summary>
        [Display(Name = "Itunes最小支持版本")]
        public string MinimumSupportediTunesVersion { get; set; }

        /// <summary>
        /// sample:iBoot-2817.20.26
        /// </summary>
        [Display(Name = "FirewareVersion")]
        public string FirewareVersion { get; set; }

        /// <summary>
        /// 系统版本 sample:9.2.1
        /// </summary>
        [Display(Name = "系统版本")]
        public string ProductVersion { get; set; }

        /// <summary>
        /// 设备详细型号，sample:iPhone 5,3
        /// </summary>
        [Display(Name = "设备详细型号")]
        public string ProductType { get; set; }

        /// <summary>
        /// sample:Iphone OS
        /// </summary>
        [Display(Name = "产品名称")]
        public string ProductName { get; set; }

        /// <summary>
        /// sample:13D15
        /// </summary>
        [Display(Name = "BuildVersion")]
        public string BuildVersion { get; set; }

        /// <summary>
        ///sample: iPhone
        /// </summary>
        [Display(Name = "设备种类")]
        public string DeviceClass { get; set; }

        /// <summary>
        /// sapmple:#ele4e3
        /// </summary>
        [Display(Name = "设备颜色")]
        public string DeviceColor { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        [Display(Name = "设备型号")]
        public DeviceModelEnum DeviceName { get; set; }


        [Display(Name = "设备型号")]
        public string DeviceNameStr
        {
            get
            {
                return DeviceName.GetName();
            }
        }

        /// <summary>
        /// sample:t700
        /// </summary>
        [Display(Name = "硬件平台")]
        public string HardwarePlatform { get; set; }

        /// <summary>
        /// sample:N61AP
        /// </summary>
        [Display(Name = "HWModelStr")]
        public string HWModelStr { get; set; }

        /// <summary>
        /// sample:A
        /// </summary>
        [Display(Name = "设备变体")]
        public string DeviceVariant { get; set; }

        /// <summary>
        /// cpu 架构
        /// </summary>
        [Display(Name = "cpu架构")]
        public CPUArchitectureEnum CPUArchitecture { get; set; }

        [Display(Name = "cpu架构")]
        public string CPUArchitectureName { get { return CPUArchitecture.GetName(); } }

        /// <summary>
        /// 用户自定义设备名称
        /// </summary>
        [Display(Name = "用户自定义设备名称"), Required(ErrorMessage = "设备名称不能为空")]
        public string UserAssignedDeviceName { get; set; }

        /// <summary>
        /// UUID
        /// </summary>
        [Display(Name = "UUID"), Required(ErrorMessage = "UUID不能为空")]
        public string UniqueDeviceId { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [Display(Name = "序列号")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// sample:MG502
        /// </summary>
        [Display(Name = "ModelNumber")]
        public string ModelNumber { get; set; }

        /// <summary>
        /// 是否使用
        /// </summary>
        [Display(Name = "是否使用")]
        public bool Enable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        public DateTime UpdateTime { get; set; }
    }
}
