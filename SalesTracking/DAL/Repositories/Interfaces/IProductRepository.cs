namespace DAL.Repositories.Interfaces
{
    using DAL.Entity;

    public interface IProductRepository : IGenericRepository<ProductEntity>
    {
        ProductEntity FindByName(string name);

    }
}