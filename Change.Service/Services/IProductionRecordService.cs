using Change.Common.Core;
using Change.Data.Data;

namespace Change.Service.Services
{
    public interface IProductionRecordService
    {
        /// <summary>
        /// 根据Id获取记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductionRecord GetById(int id);

        /// <summary>
        /// 根据包id获取记录
        /// </summary>
        /// <param name="budleId"></param>
        /// <returns></returns>
        ProductionRecord GetByBudleId(string budleId);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        void Insert(ProductionRecord entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(int id);

        /// <summary>
        /// 添加使用记录
        /// </summary>
        /// <param name="useTimes"></param>
        void AddUserRecord(int useTimes, int proRecordId);

        /// <summary>
        /// 查询生产记录
        /// </summary>
        /// <param name="qeury"></param>
        /// <returns></returns>
        IPagedList<ProductionRecord> Query(ProductionRecordQuery qeury);

        /// <summary>
        /// 查询每日生产记录
        /// </summary>
        /// <param name="qeury"></param>
        /// <returns></returns>
        IPagedList<DaliyProduction> QueryDaliyRecord(DaliyRecordQuery qeury);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        void DeleteDaliyRecord(int id);
    }
}
