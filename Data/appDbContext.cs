using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApi.Data
{
    public class appDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ContaCorrente> Contas { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    
    }
}