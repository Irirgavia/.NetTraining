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

        public IEnumerable<SaleEntity> GetByUser(int clientId)
        {
            return Context.Sales.Where(x => x.ClientId == clientId);
        }

        public IEnumerable<SaleEntity> GetByProduct(int productId)
        {
            return Context.Sales.Where(x => x.ProductId == productId);
        }

        public IEnumerable<SaleEntity> GetByDate(DateTime date)
        {
            return Context.Sales.Where(x => x.Date == date);
        }
    }
}