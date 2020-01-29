namespace DAL.Repositories.Interfaces
{
    using DAL.Entity;

    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetUserById(int id);

        UserEntity GetUserByLastName(string lastName);

        UserEntity GetUserByEmail(string email);

        void CreateUser(string firstname, string lastname, string email);

        void DeleteUser(int id);

        void UpdateUser(int id, string lastname, string firstname, string email);
    }
}