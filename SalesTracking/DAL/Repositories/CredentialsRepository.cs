namespace DAL.Repositories
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class CredentialsRepository : GenericRepository<CredentialsEntity, ClientsContext>, ICredentialsRepository
    {
        public CredentialsRepository(ClientsContext context)
            : base(context)
        {
        }

        public CredentialsEntity GetCredentialsById(int id)
        {
            return Context.Credentials.FirstOrDefault(x => x.Id == id);
        }

        public CredentialsEntity GetCredentialsByLogin(string login)
        {
            return Context.Credentials.FirstOrDefault(x => x.Login == login);
        }

        public void AddCredentials(string login, string password, RoleEntity role)
        {
            var credentials = new CredentialsEntity() { Login = login, Password = password, Role = role};
            Context.Credentials.Add(credentials);
        }

        public void DeleteCredentials(string login)
        {
            var credentials = GetCredentialsByLogin(login);
            if (credentials != null)
            {
                Context.Credentials.Remove(credentials);
            }
        }

        public void UpdateCredentials(string oldLogin, string newLogin, string password, RoleEntity role)
        {
            var credentials = GetCredentialsByLogin(oldLogin);

            if (credentials != null)
            {
                credentials.Login = newLogin;
                credentials.Password = password;
                credentials.Role = role;
            }
        }

        public string GetHashByLogin(string login)
        {
            return Context.Credentials.FirstOrDefault(x => x.Login == login)?.Password;
        }

        public bool IsLoginExists(string login)
        { 
            if (!Context.Credentials.Any())
            {
                return false;
            }

            var credentials = Context.Credentials.FirstOrDefault(x => x.Login == login);
            if (credentials == null)
            {
                return false;
            }

            return true;
        }
    }
}