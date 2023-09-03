using Bardakbot.Config;
using Bardakbots.Models;
using Bardakbots.module.bank.model;
using Microsoft.EntityFrameworkCore;

namespace Bardakbots.Data
{
    internal class BotContext : DbContext
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<BankAccount> BankAccount { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigReader config = new ConfigReader();
            optionsBuilder.UseSqlServer(config.dbConnectionString);
        }
    }
}
