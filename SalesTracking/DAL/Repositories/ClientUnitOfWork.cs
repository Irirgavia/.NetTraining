namespace DAL.Repositories
{
    using System;

    using DAL.Repositories.Interfaces;

    public class ClientUnitOfWork : IDisposable
    {
        private ClientsContext context;

        public ClientUnitOfWork()
        {
            context = new ClientsContext();
        }

        public IUserRepository UserRepository => new UserRepository(context);

        public IClientRepository ClientRepository => new ClientRepository(context);

        public ICredentialsRepository CredentialsRepository => new CredentialsRepository(context);

        public IRoleRepository RoleRepository => new RoleRepository(context);

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context?.Dispose();
            }
        }
    }
}