using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrimeStore_API.Domanin.Entities;
using PrimeStore_API.Domanin.Entities.BaseClass;
using PrimeStore_API.Domanin.Entities.Identity;
using System.Reflection;

namespace PrimeStore_API.Persistence.Context
{
    public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<MediaLibrary> MediaLibraries { get; set; }
        public DbSet<MediaLibraryFile> MediaLibraryFiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddress> OrderAddress { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<ProductSuppliers> ProductSuppliers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        private void ApplyEntityChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity baseEntity)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                baseEntity.IsEnabled = true;
                                baseEntity.IsDeleted = false;
                                baseEntity.CreateDate = DateTime.Now;
                                baseEntity.Id = Guid.NewGuid();
                                break;
                            }
                        case EntityState.Modified:
                            {
                                baseEntity.UpdateDate = DateTime.Now;
                                baseEntity.ModifiedUserId = "";
                                break;
                            }
                        case EntityState.Deleted:
                            {
                                baseEntity.IsDeleted = true;
                                baseEntity.ModifiedUserId = "";
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
        private async Task ApplyEntityChangesAsync()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity baseEntity)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                baseEntity.IsEnabled = true;
                                baseEntity.IsDeleted = false;
                                baseEntity.CreateDate = DateTime.Now;
                                baseEntity.Id = Guid.NewGuid();
                                break;
                            }
                        case EntityState.Modified:
                            {
                                baseEntity.UpdateDate = DateTime.Now;
                                baseEntity.ModifiedUserId = "";
                                break;
                            }
                        case EntityState.Deleted:
                            {
                                baseEntity.IsDeleted = true;
                                baseEntity.ModifiedUserId = "";
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
        public override int SaveChanges()
        {
            ApplyEntityChanges();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await ApplyEntityChangesAsync();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
