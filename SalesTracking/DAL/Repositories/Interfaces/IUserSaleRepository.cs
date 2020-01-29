namespace DAL.Repositories.Interfaces
{
    using DAL.Entity;

    public interface IUserSaleRepository : IGenericRepository<UserEntity>
    {
        UserEntity FindByName(string lastName);
    }
}