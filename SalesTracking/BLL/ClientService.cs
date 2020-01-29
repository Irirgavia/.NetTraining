namespace BLL
{
    using System;

    using AutoMapper;

    using BLEntity;

    using DAL.Entity;
    using DAL.Repositories;

    public class ClientService
    {
        private ClientUnitOfWork clientUnitOfWork;

        public ClientService()
        {
            this.clientUnitOfWork = new ClientUnitOfWork();
            ObjectMapper = new ObjectMapper();
        }

        public ClientService(ClientUnitOfWork clientUnitOfWork)
        {
            this.clientUnitOfWork = clientUnitOfWork;
            ObjectMapper = new ObjectMapper();
        }

        public ObjectMapper ObjectMapper { get; }

        public ClientDTO GetClientByLogin(string login)
        {
            var user = GetUserByLogin(login);
            var client = clientUnitOfWork.ClientRepository.GetClientByUser(ObjectMapper.ToDLO(user));
            if (client == null)
            {
                throw new IndexOutOfRangeException("There is no such client.");
            }

            return ObjectMapper.ToBLO(client);
        }

        public ClientDTO GetClientById(int id)
        {
            var client = clientUnitOfWork.ClientRepository.GetClientById(id);
            if (client == null)
            {
                throw new IndexOutOfRangeException("There is no such user.");
            }

            return ObjectMapper.ToBLO(client);
        }

        public UserDTO GetUserById(int id)
        {
            var user = clientUnitOfWork.UserRepository.GetUserById(id);
            if (user == null)
            {
                throw new IndexOutOfRangeException("There is no such user.");
            }

            return ObjectMapper.ToBLO(user);
        }

        public UserDTO GetUserByLogin(string login)
        {
            var credentials = clientUnitOfWork.CredentialsRepository.GetCredentialsByLogin(login);
            var user = clientUnitOfWork.ClientRepository.GetClientByCredentials(credentials);
            if (user == null)
            {
                throw new IndexOutOfRangeException("There is no such user.");
            }

            return ObjectMapper.ToBLO(user.User);
        }

        public void CreateUser(UserDTO newUser)
        {
            clientUnitOfWork.UserRepository.Create(ObjectMapper.ToDLO(newUser));
            clientUnitOfWork.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            clientUnitOfWork.UserRepository.DeleteUser(id);
            clientUnitOfWork.SaveChanges();
        }

        public void UpdateUser(UserDTO changedUser, UserDTO newUser)
        {
            var oldUser = GetUserById(changedUser.Id);
            clientUnitOfWork.UserRepository.UpdateUser(changedUser.Id, newUser.LastName, newUser.FirstName, newUser.Email);

            var client = clientUnitOfWork.ClientRepository.GetClientByUser(ObjectMapper.ToDLO(oldUser));
            clientUnitOfWork.ClientRepository.UpdateClient(client.Id, ObjectMapper.ToDLO(newUser), client.Credentials);
            clientUnitOfWork.SaveChanges();
        }

        public void UpdateClient(ClientDTO client)
        {
            clientUnitOfWork.ClientRepository.UpdateClient(client.Id, ObjectMapper.ToDLO(client.User), ObjectMapper.ToDLO(client.Credentials));
            clientUnitOfWork.SaveChanges();
        }

        public bool IsAuthenticate(string login, string password)
        {
            if (!clientUnitOfWork.CredentialsRepository.IsLoginExists(login))
            {
                throw new UnauthorizedAccessException();
            }

            return PasswordHasher.Verify(password, clientUnitOfWork.CredentialsRepository.GetHashByLogin(login));
        }

        public RoleDTO GetUserRole(int userId)
        {
            var user = clientUnitOfWork.UserRepository.GetUserById(userId);
            var role = clientUnitOfWork.ClientRepository.GetClientByUser(user).Credentials.Role;
            if (role != null)
            {
                return ObjectMapper.ToBLO(role);
            }

            return ObjectMapper.ToBLO(clientUnitOfWork.RoleRepository.GetRoleByName("User"));
        }

        public void UpdateClientRole(string login, string role)
        {
            var user = GetUserByLogin(login);
            var credentials = this.clientUnitOfWork.CredentialsRepository.GetCredentialsByLogin(login);
            clientUnitOfWork.ClientRepository.UpdateClient(user.Id, ObjectMapper.ToDLO(user), credentials);
            clientUnitOfWork.SaveChanges();
        }

        public bool CheckRole(UserDTO user, string role)
        {
            var client = clientUnitOfWork.ClientRepository.GetClientByUser(ObjectMapper.ToDLO(user));
            if (string.Equals(client.Credentials.Role.Name, role))
            {
                return true;
            }

            return false;
        }
    }
}