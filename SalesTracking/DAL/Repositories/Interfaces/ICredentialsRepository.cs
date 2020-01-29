namespace DAL.Repositories.Interfaces
{
    using DAL.Entity;

    public interface ICredentialsRepository : IGenericRepository<CredentialsEntity>
    {
        CredentialsEntity GetCredentialsById(int id);

        CredentialsEntity GetCredentialsByLogin(string login);

        void AddCredentials(string login, string password, RoleEntity role);

        void DeleteCredentials(string login);

        void UpdateCredentials(string oldLogin, string newLogin, string password, RoleEntity role);

        string GetHashByLogin(string login);

        bool IsLoginExists(string login);
    }
}