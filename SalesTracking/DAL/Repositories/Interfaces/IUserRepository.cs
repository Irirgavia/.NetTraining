namespace DAL.Repositories.Interfaces
{
    using BLEntity;

    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByName(string lastName);
    }
}