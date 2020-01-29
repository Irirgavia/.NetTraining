namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entity;
    using DAL.Repositories.Interfaces;

    public class ClientRepository : GenericRepository<ClientEntity, ClientsContext>, IClientRepository
    {
        public ClientRepository(ClientsContext context)
            : base(context)
        {
        }

        public ClientEntity GetClientById(int id)
        {
            return Context.Clients.FirstOrDefault(x => x.Id == id);
        }

        public ClientEntity GetClientByUser(UserEntity user)
        {
            return Context.Clients.FirstOrDefault(x => x.User == user);
        }

        public ClientEntity GetClientByCredentials(CredentialsEntity credentials)
        {
            return Context.Clients.FirstOrDefault(x => x.Credentials == credentials);
        }

        public void AddClient(UserEntity user, CredentialsEntity credentials)
        {
            Context.Clients.Add(new ClientEntity() { User = user, Credentials = credentials } );
        }

        public void DeleteClient(int id)
        {
            var client = GetClientById(id);
            if (client != null)
            {
                Context.Clients.Remove(client);
            }
        }

        public void DeleteClient(UserEntity user)
        {
            var client = GetClientByUser(user);
            if (client != null)
            {
                Context.Clients.Remove(client);
            }
        }

        public void UpdateClient(int id, UserEntity user, CredentialsEntity credentials)
        {
            var client = GetClientById(id);
            if (client != null)
            {
                client.User = user;
                client.Credentials = credentials;
            }
        }
    }
}