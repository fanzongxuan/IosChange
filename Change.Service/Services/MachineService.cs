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
                machine.CreateTime = DateTime.Now;
                _dbContext.Machine.Add(machine);
                _dbContext.SaveChanges();

            }
            return machine;
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
                throw new Exception("该条记录不存在");
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
                IDFA = "IDFA" + guid,
                MAC = "MAC" + guid,
                Type = "Type" + guid,
                Resolution = "Resolution" + guid,
                ResolutionZoom = "ResolutionZoom" + guid,
                Operator = "Operator" + guid,
                ConnectionType = "ConnectionType" + guid,
                BatteryStatus = "BatteryStatus" + guid,
                MachineTag = "MachineTag" + guid,
                ScreenBrightness = "ScreenBrightness" + guid,
                WifiName = "WifiName" + guid,
                NetWorkType = "NetWorkType" + guid,
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
            var mahineParamter = _dbContext.MachineParamter.FirstOrDefault(x => x.IsDeleted == false && x.Enable == true && x.MachineId == machineId);

            return mahineParamter;
        }

        public Machine GetMachineByMac(string mac)
        {
            var machine = _dbContext.Machine.AsNoTracking().FirstOrDefault(x => x.MAC == mac && x.IsDeleted == false);
            return machine;
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
            queryable = queryable.OrderByDescending(x => x.CreateTime);
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
            var result = new PagedList<Machine>(queryable, query.PageIndex, query.PageSize);
            return result;
        }

        public void SetMachineParamterEnable(int id)
        {
            if (id == 0)
                throw new ArgumentException("machineId不能为0");

            var machinePara = _dbContext.MachineParamter.AsQueryable().FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
            var machineParamList = _dbContext.MachineParamter.AsQueryable().Where(x => x.IsDeleted == false && x.MachineId == machinePara.MachineId && x.Enable == true).ToList();
            machineParamList.ForEach(x =>
            {
                x.Enable = false;
            });
            machinePara.Enable = true;
            _dbContext.SaveChanges();
        }

        public Machine UpdateMachine(Machine machine)
        {
            if (machine == null)
                throw new ArgumentNullException("machine");
            var entity = _dbContext.Machine.Find(machine.Id);
            entity.IDFA = machine.IDFA;
            entity.IDFV = machine.IDFV;
            entity.MAC = machine.MAC;
            _dbContext.SaveChanges();
            return machine;
        }
    }
}
