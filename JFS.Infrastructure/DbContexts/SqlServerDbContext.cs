using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Domain.Entities;
using JFS.Infrastructure.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace JFS.Infrastructure.DbContexts
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options) { }
        public SqlServerDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherItem> VoucherItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderCombo> OrderCombos { get; set; }
        public DbSet<ProductCombo> ProductCombos { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<ReplyFeedBack> ReplyFeedBacks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Setting> Setting { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Setting>().HasNoKey();
            //modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerDbContext).Assembly);
        }
    }
}
