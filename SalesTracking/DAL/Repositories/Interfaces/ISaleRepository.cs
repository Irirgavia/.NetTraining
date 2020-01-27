namespace DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;

    using DAL.Entity;

    public interface ISaleRepository : IGenericRepository<SaleEntity>
    {
        IEnumerable<SaleEntity> GetByUser(int clientId);

        IEnumerable<SaleEntity> GetByDate(DateTime date);
    }
}