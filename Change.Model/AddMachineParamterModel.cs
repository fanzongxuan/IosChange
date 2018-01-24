using Change.Data.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Change.Model
{
    public class AddMachineParamterModel
    {
        /// <summary>
        /// 设备Id（FK）
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        [Display(Name = "设备名称"), Required(ErrorMessage = "设备名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 设备本地名称
        /// </summary>
        [Display(Name = "设备本地名称"), Required(ErrorMessage = "设备本地名称不能为空")]
        public string LocalName { get; set; }

        /// <summary>
        /// 设备系统名称
        /// </summary>
        [Display(Name = "设备系统名称")]
        public string SystemName { get; set; }

        /// <summary>
        /// 设备机型：iPhone,iPad,iTouch 三种
        /// </summary>
        [Display(Name = "设备机型"), Required(ErrorMessage = "请选择机型")]
        public DeviceModelEnum DeviceModel { get; set; }

        /// <summary>
        /// UUID
        /// </summary>
        [Display(Name = "UUID"), Required(ErrorMessage = "UUID不能为空")]
        public string UUID { get; set; }

        /// <summary>
        /// IDFV
        /// </summary>
        [Display(Name = "IDFV"), Required(ErrorMessage = "IDFV不能为空")]
        public string IDFV { get; set; }

        /// <summary>
        /// 系统版本
        /// </summary>
        [Display(Name = "SystemVersion"), Required(ErrorMessage = "系统版本不能为空")]
        public string SystemVersion { get; set; }

        /// <summary>
        /// IDFV
        /// </summary>
        [Display(Name = "IDFA"), Required(ErrorMessage = "IDFA不能为空")]
        public string IDFA { get; set; }

        /// <summary>
        /// mac 地址
        /// </summary>
        [Display(Name = "MAC"), Required(ErrorMessage = "MAC不能为空")]
        public string MAC { get; set; }

        /// <summary>
        /// 手机类型
        /// </summary>
        [Display(Name = "Type"), Required(ErrorMessage = "手机类型不能为空")]
        public string Type { get; set; }

        /// <summary>
        /// 分辨率
        /// </summary>
        [Display(Name = "分辨率"), Required(ErrorMessage = "分辨率不能为空")]
        public string Resolution { get; set; }

        /// <summary>
        /// 分辨率缩放
        /// </summary>
        [Display(Name = "分辨率缩放")]
        public string ResolutionZoom { get; set; }

        /// <summary>
        /// 运营商
        /// </summary>
        [Display(Name = "运营商"), Required(ErrorMessage = "请选择运营商")]
        public CarrierNameEnum CarrierName { get; set; }

        /// <summary>
        /// 电池状态
        /// </summary>
        [Display(Name = "电池状态"), Required(ErrorMessage = "请选电池状态")]
        public BatteryStatusEnum BatteryStatus { get; set; }

        /// <summary>
        /// 电池电量，不指定会自动随机 0.600000~0.800000 电量，如 0.670000
        /// </summary>
        [Display(Name = "电池电量")]
        public float BatteryLevel { get; set; }

        /// <summary>
        /// 设备标签
        /// </summary>
        [Display(Name = "设备标签")]
        public string MachineTag { get; set; }

        /// <summary>
        /// 屏幕亮度
        /// </summary>
        [Display(Name = "屏幕亮度")]
        public string ScreenBrightness { get; set; }

        /// <summary>
        /// wifi名称
        /// </summary>
        [Display(Name = "wifi名称")]
        public string WifiName { get; set; }

        /// <summary>
        /// 联网类型
        /// </summary>
        [Display(Name = "联网类型")]
        public NetWorkTypeEnum NetWorkType { get; set; }

        /// <summary>
        /// 本地语言
        /// </summary>
        [Display(Name = "本地语言")]
        public string LocalLanguage { get; set; }

        /// <summary>
        /// IMEI
        /// </summary>
        [Display(Name = "IMEI")]
        public string IMEI { get; set; }

        /// <summary>
        /// 销售地区
        /// </summary>
        [Display(Name = "销售地区")]
        public string SaleArea { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public bool Enable { get; set; }
    }
}
