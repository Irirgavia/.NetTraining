namespace DAL.Repositories
{
    using System.Linq;

    using BLEntity;

    using DAL.Repositories.Interfaces;

    public class ProductRepository : GenericRepository<Product, SalesContext>, IProductRepository
    {
        public ProductRepository(SalesContext context)
            : base(context)
        {
        }

        public Product FindByName(string name)
        {
            return Context.Products.FirstOrDefault(x => x.Name == name);
        }
    }
}