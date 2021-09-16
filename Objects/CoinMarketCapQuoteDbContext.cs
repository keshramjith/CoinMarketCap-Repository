using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepoWebAPI.Entities;

namespace RepoWebAPI.Objects
{
    public class CoinMarketCapQuoteDbContext : DbContext
    {
        /*
         * Setups dbcontext with connection string
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json")).Build();
            var connString = config.GetSection("ConnectionStrings")["CoinMarketCapDbConnection"];
            optionsBuilder.UseSqlServer(connString);
        }

        /*
         * Applies configurations to modelbuilder
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new QuoteEntityConfiguration());
        }
    }
}