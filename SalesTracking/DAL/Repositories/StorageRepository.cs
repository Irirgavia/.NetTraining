namespace DAL.Repositories
{
    using System;

    using DAL.Repositories.Interfaces;

    public class StorageRepository : IStorageRepository
    {
        public StorageRepository()
        {
            Context = new SalesContext();
        }

        public IUserRepository UserRepository => new UserRepository(Context);

        public ISaleRepository SaleRepository => new SaleRepository(Context);

        public IProductRepository ProductRepository => new ProductRepository(Context);

        public IRecordFileRepository RecordFileRepository => new RecordFileRepository(Context);

        private SalesContext Context { get; }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}