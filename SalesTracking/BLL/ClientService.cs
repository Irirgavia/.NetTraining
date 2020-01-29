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

        public ClientService(ClientUnitOfWork clientUnitOfWork)
        {
            this.clientUnitOfWork = clientUnitOfWork;
        }

        public UserDTO GetUserById(int id)
        {
            var user = clientUnitOfWork.UserRepository.GetUserById(id);
            if (user == null)
            {
                throw new IndexOutOfRangeException("There is no such user.");
            }

            return Mapper.Map<UserDTO>(user);
        }

        public UserDTO GetUserByLogin(string login)
        {
            var credentials = clientUnitOfWork.CredentialsRepository.GetCredentialsByLogin(login);
            var user = clientUnitOfWork.ClientRepository.GetClientByCredentials(credentials);
            if (user == null)
            {
                throw new IndexOutOfRangeException("There is no such user.");
            }

            return Mapper.Map<UserDTO>(user);
        }

        public void CreateUser(UserDTO newUser)
        {
            if (clientUnitOfWork.CredentialsRepository.IsLoginExists(newUser.UserName))
            {
                throw new ArgumentException("Such login already exists.");
            }

            clientUnitOfWork.UserRepository.Create(Mapper.Map<UserEntity>(newUser));
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

            var client = clientUnitOfWork.ClientRepository.GetClientByUser(Mapper.Map<UserEntity>(oldUser));
            clientUnitOfWork.ClientRepository.UpdateClient(client.Id, Mapper.Map<UserEntity>(newUser), client.Credentials);
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
                return Mapper.Map<RoleDTO>(role);
            }

            return Mapper.Map<RoleDTO>(clientUnitOfWork.RoleRepository.GetRoleByName("User"));
        }

        public void UpdateClientRole(string login, string role)
        {
            var user = GetUserByLogin(login);
            var credentials = this.clientUnitOfWork.CredentialsRepository.GetCredentialsByLogin(login)
            clientUnitOfWork.ClientRepository.UpdateClient(user.Id, Mapper.Map<UserEntity>(user), credentials);
            clientUnitOfWork.SaveChanges();
        }

        public bool CheckRole(UserDTO user, string role)
        {
            var client = clientUnitOfWork.ClientRepository.GetClientByUser(Mapper.Map<UserDTO>(user));
            if (string.Equals(client.Credentials.Role.Name, role))
            {
                return true;
            }

            return false;
        }
    }
}