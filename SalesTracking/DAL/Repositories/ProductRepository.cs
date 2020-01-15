namespace DAL.Repositories
{
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class ProductRepository : GenericRepository<ProductEntity, SalesContext>, IProductRepository
    {
        public ProductRepository(SalesContext context)
            : base(context)
        {
        }

        public ProductEntity FindByName(string name)
        {
            return Context.Products.FirstOrDefault(x => x.Name == name);
        }
    }
}