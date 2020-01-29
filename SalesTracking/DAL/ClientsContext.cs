namespace DAL
{
    using System.Data.Entity;

    using DAL.Entity;

    public class ClientsContext : DbContext
    {
        public ClientsContext()
            : base("ClientContext")
        {
        }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<CredentialsEntity> Credentials { get; set; }

        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().ToTable("Roles");
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<CredentialsEntity>().ToTable("Credentials");
            modelBuilder.Ignore<ClientsContext>();

            modelBuilder.Entity<CredentialsEntity>()
                .HasRequired(c => c.Role);

            modelBuilder.Entity<ClientEntity>()
                .HasRequired(c => c.Credentials);

            modelBuilder.Entity<ClientEntity>()
                .HasRequired(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}