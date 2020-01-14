namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using BLEntity;

    using DAL.Repositories.Interfaces;

    public class RecordFileRepository : GenericRepository<RecordFile, SalesContext>, IRecordFileRepository
    {
        public RecordFileRepository(SalesContext context)
            : base(context)
        {
        }

        public RecordFile GetByFileName(string fileName)
        {
            return Context.RecordFiles.FirstOrDefault(x => x.FileName == fileName);
        }

        public IEnumerable<RecordFile> GetByUserId(int managerId)
        {
            return Context.RecordFiles.Where(x => x.ManagerId == managerId);
        }
    }
}