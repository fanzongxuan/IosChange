using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Change.Common.Core;
using Change.Data;
using Change.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Change.Service.Services
{
    public class MachineService : IMachineService
    {
        private readonly ChangeDbContext _dbContext;

        public MachineService(ChangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Machine AddMachineIfNotExist(Machine machine)
        {
            var entity = GetMachineByMac(machine.MAC);
            if (entity == null)
            {
                //新增记录并保存并启用自定义参数
                machine.CreateTime = DateTime.Now;
                machine.EnableMachineParaters = true;
                _dbContext.Machine.Add(machine);
                _dbContext.SaveChanges();

                //新增自定义参数并启用
                var param = GenerateMachineParamter(machine.Id);
                SetMachineParamterEnable(param.Id, true);

                return machine;
            }
            else
            {
                return entity;
            }
        }

        public MachineParamter AddMachineParamters(MachineParamter paramter)
        {
            if (paramter == null)
                throw new ArgumentNullException("paramter");

            paramter.CreateTime = DateTime.Now;
            paramter.UpdateTime = DateTime.Now;
            _dbContext.MachineParamter.Add(paramter);
            _dbContext.SaveChanges();
            return paramter;
        }

        public void DeleteMachine(int id)
        {
            if (id == 0)
                throw new ArgumentException("id 不能为0");
            var machine = _dbContext.Machine.AsQueryable().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (machine != null)
            {
                machine.IsDeleted = true;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("该机器不存在");
            }
        }

        public void DeleteMachineParamter(int id)
        {
            if (id == 0)
                throw new ArgumentException("id 不能为0");
            var machineParamters = _dbContext.MachineParamter.AsQueryable().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (machineParamters != null)
            {
                machineParamters.IsDeleted = true;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("该条记录不存在");
            }
        }

        public MachineParamter GenerateMachineParamter(int machineId)
        {
            if (machineId == 0)
                throw new ArgumentException("machineId不能为0");

            var guid = new Guid().ToString();
            //todo 机器参数生成待确定
            var entity = new MachineParamter()
            {
                Name = "Name" + guid,
                LocalName = "LocalName" + guid,
                SystemName = "SystemName" + guid,
                UUID = "UUID" + guid,
                IDFV = "IDFV" + guid,
                SystemVersion = "SystemVersion" + guid,
                DeviceModel = DeviceModelEnum.iPhone,
                IDFA = "IDFA" + guid,
                MAC = "MAC" + guid,
                Type = "Type" + guid,
                Resolution = "Resolution" + guid,
                ResolutionZoom = "ResolutionZoom" + guid,
                CarrierName = CarrierNameEnum.ChinaMoblie,
                BatteryStatus = BatteryStatusEnum.NoCharge,
                BatteryLevel = 0.6f,
                MachineTag = "MachineTag" + guid,
                ScreenBrightness = "ScreenBrightness" + guid,
                WifiName = "WifiName" + guid,
                NetWorkType = NetWorkTypeEnum.FrouthGen,
                LocalLanguage = "LocalLanguage" + guid,
                IMEI = "IMEI" + guid,
                SaleArea = "SaleArea" + guid,
                Enable = false,
                MachineId = machineId,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public MachineParamter GetInUseMachineParamter(int machineId)
        {
            if (machineId == 0)
                throw new ArgumentException("machineId 不能为0");

            var machine = _dbContext.Machine.Where(x => x.Id == machineId && x.IsDeleted == false).FirstOrDefault();

            if (machine.EnableMachineParaters)
            {
                var mahineParamter = _dbContext.MachineParamter.FirstOrDefault(x => x.IsDeleted == false && x.Enable == true && x.MachineId == machineId);
                return mahineParamter;
            }
            else
            {
                throw new ArgumentException("该机器没有启用自定义参数");
            }
        }

        public Machine GetMachineByMac(string mac)
        {
            var machine = _dbContext.Machine.AsNoTracking().FirstOrDefault(x => x.MAC == mac && x.IsDeleted == false);
            return machine;
        }

        public MachineParamter GetMachineParamterById(int id)
        {
            if (id == 0)
                throw new ArgumentException("id不能为0");
            var entity = _dbContext.MachineParamter.Find(id);
            if (entity == null || entity.IsDeleted)
                throw new ArgumentNullException("该设备不存在");
            return entity;
        }

        public IPagedList<MachineParamter> MachineParamterQuery(MachineParamterQuery query)
        {
            var queryable = _dbContext.MachineParamter.AsNoTracking().Where(x => x.IsDeleted == false);
            if (query.MachineId != 0)
                queryable = queryable.Where(x => x.MachineId == query.MachineId);
            if (query.FromTime.HasValue)
                queryable = queryable.Where(x => x.CreateTime >= query.FromTime);
            if (query.ToTime.HasValue)
                queryable = queryable.Where(x => x.CreateTime <= query.ToTime);
            queryable = queryable.OrderByDescending(x => x.Id);
            var result = new PagedList<MachineParamter>(queryable, query.PageIndex, query.PageSize);
            return result;
        }

        public IPagedList<Machine> MachineQuery(MachineQuery query)
        {
            var queryable = _dbContext.Machine.AsNoTracking().Where(x => x.IsDeleted == false);
            if (query.FromTime.HasValue)
                queryable = queryable.Where(x => x.CreateTime >= query.FromTime);
            if (query.ToTime.HasValue)
                queryable = queryable.Where(x => x.CreateTime <= query.ToTime);
            queryable = queryable.OrderByDescending(x => x.Id);
            var result = new PagedList<Machine>(queryable, query.PageIndex, query.PageSize);
            return result;
        }

        public void SetMachineEnable(int id, bool enable)
        {
            if (id == 0)
                throw new ArgumentNullException("id不能为0!");

            var machine = _dbContext.Machine.Find(id);
            if (machine == null || machine.IsDeleted)
                throw new ArgumentNullException($"id为{id}的机器不存在!");
            machine.EnableMachineParaters = enable;
            _dbContext.SaveChanges();

        }

        public void SetMachineParamterEnable(int id, bool enable)
        {
            if (id == 0)
                throw new ArgumentException("machineId不能为0");

            var machineParam = _dbContext.MachineParamter.AsQueryable().FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
            if (enable)
            {
                var machineParamList = _dbContext.MachineParamter.AsQueryable().Where(x => x.IsDeleted == false && x.MachineId == machineParam.MachineId && x.Enable == true).ToList();
                machineParamList.ForEach(x =>
                {
                    x.Enable = false;
                });
                machineParam.Enable = true;
            }
            else
            {
                machineParam.Enable = false;
            }

            _dbContext.SaveChanges();
        }

        public Machine UpdateMachine(Machine machine)
        {
            if (machine == null)
                throw new ArgumentNullException("machine");
            var entity = _dbContext.Machine.Find(machine.Id);
            if (entity.IsDeleted)
                throw new ArgumentNullException("该设备不存在");

            entity.IDFA = machine.IDFA;
            entity.IDFV = machine.IDFV;
            entity.MAC = machine.MAC;
            _dbContext.SaveChanges();
            return machine;
        }
    }
}
