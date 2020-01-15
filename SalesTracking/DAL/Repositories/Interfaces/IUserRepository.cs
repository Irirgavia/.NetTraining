namespace DAL.Repositories.Interfaces
{
    using DAL.Entity;

    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity FindByName(string lastName);
    }
}