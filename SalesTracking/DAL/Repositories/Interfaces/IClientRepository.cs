namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entity;

    public interface IClientRepository : IGenericRepository<ClientEntity>
    {
        ClientEntity GetClientById(int id);

        ClientEntity GetClientByUser(UserEntity user);

        ClientEntity GetClientByCredentials(CredentialsEntity credentials);

        void AddClient(UserEntity user, CredentialsEntity credentials);

        void DeleteClient(int id);

        void DeleteClient(UserEntity user);

        void UpdateClient(int id, UserEntity user, CredentialsEntity credentials);
    }
}