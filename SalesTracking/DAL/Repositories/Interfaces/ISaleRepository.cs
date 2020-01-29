namespace DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;

    using DAL.Entity;

    public interface ISaleRepository : IGenericRepository<SaleEntity>
    {
        IEnumerable<SaleEntity> GetByUserId(int userId);

        IEnumerable<SaleEntity> GetByUser(UserEntity user);

        IEnumerable<SaleEntity> GetByDate(DateTime date);
    }
}