using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Change.Common.Core;
using Change.Data;
using Change.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Change.Service.Services
{
    public class MachineService : IMachineService
    {
        private readonly ChangeDbContext _dbContext;
        private readonly ILogger _logger;

        public MachineService(ChangeDbContext dbContext,
            ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            this._logger = loggerFactory.CreateLogger("ioschange-api");
        }

        #region Uitites

        private string GetRandomUserAssignedDeviceName()
        {
            string[] s1 = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Random rand = new Random();
            int length = rand.Next(4, 10);
            return GetRandomStringFormArrary(s1, length);
        }

        private string GetRandomSerialNumber()
        {
            string[] s1 = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return GetRandomStringFormArrary(s1, 12);
        }

        private string GetRandomUDID()
        {
            string[] s1 = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return GetRandomStringFormArrary(s1, 40);
        }


        private string GetRandomProductVersion()
        {
            string[] versions = {"9.0","9.0.1","9.0.1","9.0.2","9.1","9.2","9.2.1","9.3","9.3.1","9.3.2","9.3.3,",
                "10.0.2","10.0.3","10.1","10.1.1","10.2","10.2.1","10.3","10.3.1","10.3.2","10.3.3","11.0.3","11.1","11.1.1","11.1.2","11.2","11.2.1","11.2.2","11.2.5","11.2.6"};
            return GetRandomStringFormArrary(versions, 1);
        }

        private string GetRandomStringFormArrary(string[] strings, int length)
        {
            string result = "";
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                result += strings[rand.Next(0, strings.Length)];
            }

            return result;
        }


        private bool IsInWhiteList(string budleId)
        {
            string[] whiteList = { "com.apple.Preferences", "com.apple.springboard", "com.apple.UIkit","com.apple.AppStore", "com.apple.FamilyCircle", "com.apple.mobilecal.widget" };
            return whiteList.Contains(budleId);
        }
        #endregion

        public Machine AddMachineIfNotExist(Machine machine)
        {
            var entity = GetMachineByIP(machine.Ip);
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
                //ActiveWirelessTechnology= "kCTWirelessTechnologyUnkonwn",
                //WifiVendor= "Murata",
                //RegionInfo="LL/A",
                //RegionCode="LL",
                //MinimumSupportediTunesVersion = "12.2.2",
                //FirewareVersion= "iBoot-2817.20.26",
                ProductVersion = GetRandomProductVersion(),
                //ProductType = "iPhone 5,3",
                //ProductName= "Iphone OS",
                //BuildVersion= "13D15",
                //DeviceClass= "iPhone",
                //DeviceColor= "#ele4e3",
                //DeviceName= DeviceModelEnum.iPhone,
                UserAssignedDeviceName = GetRandomUserAssignedDeviceName(),
                //HardwarePlatform= "t700",
                //HWModelStr= "N61AP",
                //DeviceVariant="A",
                //CPUArchitecture= CPUArchitectureEnum.armv7s,
                UniqueDeviceId = GetRandomUDID(),
                SerialNumber = GetRandomSerialNumber(),
                //ModelNumber="MG502",
                Enable = false,
                MachineId = machineId,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public MachineParamter GetInUseMachineParamter(int machineId, string budleId)
        {
            if (machineId == 0)
                throw new ArgumentException("machineId 不能为0");

            var query = _dbContext.Machine.
                Where(x => x.Id == machineId && x.IsDeleted == false);

            if (!string.IsNullOrEmpty(budleId))
            {
                if (!IsInWhiteList(budleId))
                    query = query.Where(x => x.ImpactBudleIds.Any(y => y.IsDeleted == false && y.BudleId == budleId));
            }

            var machine = query.FirstOrDefault();
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

        public Machine GetMachineByIP(string uuid)
        {
            var machine = _dbContext.Machine.AsNoTracking().FirstOrDefault(x => x.Ip == uuid && x.IsDeleted == false);
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

            entity.Ip = machine.Ip;
            _dbContext.SaveChanges();
            return machine;
        }

        #region BudleIds

        /// <summary>
        /// 添加作用包名
        /// </summary>
        /// <param name="budleIds"></param>
        /// <param name="machineId"></param>
        /// <returns></returns>
        public void AddImpactBudleIds(List<string> budleIds, int machineId)
        {
            budleIds = budleIds.Distinct().ToList(); ;
            var exsitBudleIds = _dbContext.ImpactBudleId.
                Where(x => x.MachineId == machineId && x.IsDeleted == false).
                ToList().
                Select(x => { return x.BudleId; });

            var needToAddBudleIds = budleIds.Except(exsitBudleIds).Select(x =>
            {
                return new ImpactBudleId()
                {
                    MachineId = machineId,
                    BudleId = x
                };
            });

            _dbContext.ImpactBudleId.AddRange(needToAddBudleIds);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 删除作用包名
        /// </summary>
        /// <param name="budleIds"></param>
        public void DeleteBudleIds(List<string> budleIds, int machineId)
        {
            budleIds = budleIds.Distinct().ToList(); ;
            foreach (var item in budleIds)
            {
                var needToDeleteBudleId = _dbContext.ImpactBudleId.FirstOrDefault(x => x.IsDeleted == false && x.MachineId == machineId && x.BudleId == item);
                needToDeleteBudleId.IsDeleted = false;
            }
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
