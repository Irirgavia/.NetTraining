namespace DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLEntity;

    public interface ISaleRepository : IGenericRepository<Sale>
    {
        IEnumerable<Sale> GetByUser(int clientId);

        IEnumerable<Sale> GetByProduct(int productId);

        IEnumerable<Sale> GetByDate(DateTime date);
    }
}