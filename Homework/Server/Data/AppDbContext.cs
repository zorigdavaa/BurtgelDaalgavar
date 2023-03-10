using Homework.Shared.DTO;
using Homework.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using ServerMVC.Controllers;
using System.Diagnostics;

namespace Homework.Server.Data
{
    public class AppDbContext : DbContext
    {
        #region Contructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
            //Debug.WriteLine($"Using database provider: {Database.ProviderName}");
            Database.EnsureCreated();
        }
        #endregion

        #region Public properties
        public DbSet<Product> Product { get; set; }
        public DbSet<WareHouse> WareHouse { get; set; }
        public DbSet<TransactionProd> Transactions { get; set; }
        public DbSet<WareProduct> WareHouseProducts { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WareProduct>()
                .HasOne(p => p.WareHouse)
                .WithMany(w => w.Items)
                .HasForeignKey(p => p.WareHouseId);
            modelBuilder.Entity<Product>()
                .Property(p => p.Code)
                .ValueGeneratedOnAdd();



            modelBuilder.Entity<Product>().HasData(GetProducts());
            modelBuilder.Entity<WareHouse>().HasData(GetWareHouses());
            base.OnModelCreating(modelBuilder);
        }

        internal void DeleteDB()
        {
            Database.EnsureDeleted();
            Dispose();
        }
        #endregion


        #region Private methods
        private List<Product> GetProducts()
        {
            return new List<Product>()
                {
                    new Product{Id = 1, Name = "Chiher", Price = 10, Meas = UnitMeas.KG,Code = 1},
                    new Product{Id = 2, Name = "Jims", Price = 20, Meas = UnitMeas.Boodol, Code = 2},
                    new Product{Id = 3, Name = "Chocolate", Price = 30, Meas = UnitMeas.Box, Code = 3},
                    new Product{Id = 4, Name = "Mashin", Price = 40, Meas = UnitMeas.Unit, Code = 4}
                };
        }
        private List<WareHouse> GetWareHouses()
        {
            return new List<WareHouse>()
                {
                    new WareHouse() { Id = 1, Name = "Central"},
                    new WareHouse() { Id = 2, Name = "West"},
                    new WareHouse() { Id = 3, Name = "East"},
                    new WareHouse() { Id = 4, Name = "North"}
                };
        }
        #endregion
    }
}
