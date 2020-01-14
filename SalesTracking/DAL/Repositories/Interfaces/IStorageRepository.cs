namespace DAL.Repositories.Interfaces
{
    using System;

    public interface IStorageRepository : IDisposable
    {
        IUserRepository UserRepository { get; }

        ISaleRepository SaleRepository { get; }

        IProductRepository ProductRepository { get; }

        IRecordFileRepository RecordFileRepository { get; }

        void SaveChanges();
    }
}