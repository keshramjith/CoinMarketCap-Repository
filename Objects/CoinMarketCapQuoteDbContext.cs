using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepoWebAPI.Entities;

namespace RepoWebAPI.Objects
{
    public class CoinMarketCapQuoteDbContext : DbContext
    {
        public DbSet<CoinMarketCapQuote> CoinMarketCapQuotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json")).Build();
            var connString = config.GetSection("ConnectionStrings")["CoinMarketCapDbConnection"];
            optionsBuilder.UseSqlServer(connString);
        }
    }
}