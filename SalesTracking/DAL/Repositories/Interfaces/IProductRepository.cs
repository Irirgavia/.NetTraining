namespace DAL.Repositories.Interfaces
{
    using BLEntity;

    public interface IProductRepository : IGenericRepository<Product>
    {
        Product FindByName(string name);

    }
}