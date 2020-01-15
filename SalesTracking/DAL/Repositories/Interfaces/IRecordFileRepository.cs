namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entity;

    public interface IRecordFileRepository : IGenericRepository<RecordFileEntity>
    {
        RecordFileEntity GetByFileName(string fileName);

        IEnumerable<RecordFileEntity> GetByUserId(int managerId);
    }
}