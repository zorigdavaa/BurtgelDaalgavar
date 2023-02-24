using Homework.Shared;
using Microsoft.EntityFrameworkCore;
using ServerMVC.Controllers;
using Shared;
using System.Diagnostics;

namespace Homework.Server.Data
{
    public class AppDbContext : DbContext
    {
        #region Contructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public properties
        public DbSet<Product> Product { get; set; }
        public DbSet<WareHouse> WareHouse { get; set; }
        public DbSet<TransactionProd> Transactions { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Debug.WriteLine("Model Creating " + modelBuilder);
            modelBuilder.Entity<Product>().HasData(GetProducts());
            modelBuilder.Entity<WareHouse>().HasData(GetWareHouses());
            base.OnModelCreating(modelBuilder);
        }
        #endregion


        #region Private methods
        private List<Product> GetProducts()
        {
            return ProductController.baraaList;
        }
        private List<WareHouse> GetWareHouses()
        {
            return WareHouseController.wareHouses;
        }
        #endregion
    }
}
