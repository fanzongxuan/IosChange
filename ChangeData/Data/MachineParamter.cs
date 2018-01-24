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
        /// 设备名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设备本地名称
        /// </summary>
        public string LocalName { get; set; }

        /// <summary>
        /// 设备系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 设备机型：iPhone,iPad,iTouch 三种
        /// </summary>
        public DeviceModelEnum DeviceModel { get; set; }

        /// <summary>
        /// UUID
        /// </summary>
        public string UUID { get; set; }

        /// <summary>
        /// IDFV
        /// </summary>
        public string IDFV { get; set; }

        /// <summary>
        /// 系统版本
        /// </summary>
        public string SystemVersion { get; set; }

        /// <summary>
        /// IDFV
        /// </summary>
        public string IDFA { get; set; }

        /// <summary>
        /// mac 地址
        /// </summary>
        public string MAC { get; set; }

        /// <summary>
        /// 设备详细型号，iPhone 5,3
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 分辨率
        /// </summary>
        public string Resolution { get; set; }

        /// <summary>
        /// 分辨率缩放
        /// </summary>
        public string ResolutionZoom { get; set; }

        /// <summary>
        /// 运营商
        /// </summary>
        public CarrierNameEnum CarrierName { get; set; }
        
        /// <summary>
        /// 电池状态，0 - 无法取得充电状态，1 - 非充电状态，2 - 充电状态，3 - 充满状态
        /// </summary>
        public BatteryStatusEnum BatteryStatus { get; set; }

        /// <summary>
        /// 电池电量，不指定会自动随机 0.600000~0.800000 电量，如 0.670000
        /// </summary>
        public float BatteryLevel { get; set; }

        /// <summary>
        /// 设备标签
        /// </summary>
        public string MachineTag { get; set; }

        /// <summary>
        /// 屏幕亮度
        /// </summary>
        public string ScreenBrightness { get; set; }

        /// <summary>
        /// wifi 名称
        /// </summary>
        public string WifiName { get; set; }

        /// <summary>
        /// 联网类型
        /// </summary>
        public NetWorkTypeEnum NetWorkType { get; set; }

        /// <summary>
        /// 本地语言
        /// </summary>
        public string LocalLanguage { get; set; }

        /// <summary>
        /// IMEI
        /// </summary>
        public string IMEI { get; set; }

        /// <summary>
        /// 销售地区
        /// </summary>
        public string SaleArea { get; set; }

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
