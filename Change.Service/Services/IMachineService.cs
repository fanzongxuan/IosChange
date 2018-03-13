using System;
using System.Collections.Generic;
using Change.Common.Core;
using Change.Data.Data;

namespace Change.Service.Services
{
    public interface IMachineService
    {
        #region Machine

        /// <summary>
        /// 根据mac地址获取机器
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        Machine GetMachineByIP(string ip);

        /// <summary>
        /// 新增machine
        /// </summary>
        /// <param name="machine"></param>
        Machine AddMachineIfNotExist(Machine machine);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void DeleteMachine(int id);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        Machine UpdateMachine(Machine machine);

        /// <summary>
        /// 机器查询
        /// </summary>
        /// <returns></returns>
        IPagedList<Machine> MachineQuery(MachineQuery query);

        /// <summary>
        /// 启用自定义参数
        /// </summary>
        /// <param name="id"></param>
        void SetMachineEnable(int id, bool enable);

        #endregion

        #region MachineParamters

        /// <summary>
        /// 添加改机参数
        /// </summary>
        /// <param name="paramter"></param>
        /// <returns></returns>
        MachineParamter AddMachineParamters(MachineParamter paramter);

        /// <summary>
        /// 获取启用的机器参数
        /// </summary>
        /// <param name="machineId"></param>
        /// <param name="budleId">app 包名</param>
        /// <returns></returns>
        MachineParamter GetInUseMachineParamter(int machineId, string budleId);

        /// <summary>
        /// 随机生成机器参数
        /// </summary>
        /// <returns></returns>
        MachineParamter GenerateMachineParamter(int machineId);

        /// <summary>
        /// 删除机器参数
        /// </summary>
        /// <param name="id"></param>
        void DeleteMachineParamter(int id);

        /// <summary>
        /// 机器参数查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IPagedList<MachineParamter> MachineParamterQuery(MachineParamterQuery query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MachineParamter GetMachineParamterById(int id);

        /// <summary>
        /// 启用机器记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enable"></param>
        void SetMachineParamterEnable(int id, bool enable);

        #endregion

        #region BudleIds

        /// <summary>
        /// 添加作用包名
        /// </summary>
        /// <param name="budleIds"></param>
        /// <param name="machineId"></param>
        /// <returns></returns>
        void AddImpactBudleIds(List<string> budleIds, int machineId);

        /// <summary>
        /// 删除作用包名
        /// </summary>
        /// <param name="budleIds"></param>
        /// <param name="machineId"></param>
        void DeleteBudleIds(List<string> budleIds, int machineId);

        #endregion
    }
}
