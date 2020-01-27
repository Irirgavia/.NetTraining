namespace DAL.Repositories
{
    using System;

    using DAL.Repositories.Interfaces;

    public class UnitOfWork : IDisposable
    {
        private SalesContext context;

        public UnitOfWork()
        {
            this.context = new SalesContext();
        }

        public IUserRepository UserRepository => new UserRepository(this.context);

        public ISaleRepository SaleRepository => new SaleRepository(this.context);

        public IProductRepository ProductRepository => new ProductRepository(this.context);

        public IRecordFileRepository RecordFileRepository => new RecordFileRepository(this.context);

        public void SaveChanges()
        {
            this.context.SaveChanges();
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
                this.context?.Dispose();
            }
        }
    }
}