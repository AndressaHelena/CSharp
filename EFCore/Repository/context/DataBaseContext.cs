using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;


namespace EFCore.Repository.Context
{
    public class DataBaseContext : DbContext
    {

        public DbSet<CadastroPessoa>? CadastroPessoa { get; set; }

        public DbSet<CadrastroPet> CadrastroPet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("FiapSmartCityConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}