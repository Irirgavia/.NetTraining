namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class RecordFileRepository : GenericRepository<RecordFileEntity, SalesContext>, IRecordFileRepository
    {
        public RecordFileRepository(SalesContext context)
            : base(context)
        {
        }

        public RecordFileEntity GetByFileName(string fileName)
        {
            return Context.RecordFiles.FirstOrDefault(x => x.FileName == fileName);
        }

        public IEnumerable<RecordFileEntity> GetByUserId(int managerId)
        {
            return Context.RecordFiles.Where(x => x.ManagerId == managerId);
        }
    }
}