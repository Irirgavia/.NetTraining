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

        public IUserSaleRepository UserRepository => new UserSaleRepository(context);

        public ISaleRepository SaleRepository => new SaleRepository(context);

        public IProductRepository ProductRepository => new ProductRepository(context);

        public IRecordFileRepository RecordFileRepository => new RecordFileRepository(context);

        public void SaveChanges()
        {
            context.SaveChanges();
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
                context?.Dispose();
            }
        }
    }
}