namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class SaleRepository : GenericRepository<SaleEntity, SalesContext>, ISaleRepository
    {
        public SaleRepository(SalesContext context)
            : base(context)
        {
        }

        public IEnumerable<SaleEntity> GetByUser(int userId)
        {
            return Context.Sales.Where(x => x.User.Id == userId);
        }

        public IEnumerable<SaleEntity> GetByDate(DateTime date)
        {
            return Context.Sales.Where(x => x.Date == date);
        }
    }
}