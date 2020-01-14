namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLEntity;

    using DAL.Repositories.Interfaces;

    public class SaleRepository : GenericRepository<Sale, SalesContext>, ISaleRepository
    {
        public SaleRepository(SalesContext context)
            : base(context)
        {
        }

        public IEnumerable<Sale> GetByUser(int clientId)
        {
            return Context.Sales.Where(x => x.ClientId == clientId);
        }

        public IEnumerable<Sale> GetByProduct(int productId)
        {
            return Context.Sales.Where(x => x.ProductId == productId);
        }

        public IEnumerable<Sale> GetByDate(DateTime date)
        {
            return Context.Sales.Where(x => x.Date == date);
        }
    }
}