namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using BLEntity;

    public interface IRecordFileRepository : IGenericRepository<RecordFile>
    {
        RecordFile GetByFileName(string fileName);

        IEnumerable<RecordFile> GetByUserId(int managerId);
    }
}