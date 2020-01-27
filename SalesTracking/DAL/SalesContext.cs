namespace DAL
{
    using System.Data.Entity;

    using DAL.Entity;

    public class SalesContext : DbContext
    {
        static SalesContext()
        {
            // Database.SetInitializer<SalesContext>(new SalesContextInitializer());
        }

        public SalesContext()
            : base("SalesContext")
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<SaleEntity> Sales { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RecordFileEntity> RecordFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().ToTable("Products");
            modelBuilder.Entity<RecordFileEntity>().ToTable("RecordFiles");
            modelBuilder.Entity<ProductEntity>().ToTable("Products");
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Ignore<SalesContext>();

            modelBuilder.Entity<RecordFileEntity>().HasRequired(u => u.User);
            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.Sales)
                .WithRequired(s => s.User);
            base.OnModelCreating(modelBuilder);
        }
    }
}
