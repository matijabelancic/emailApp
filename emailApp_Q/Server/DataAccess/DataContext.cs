using emailApp_Q.Server.DataAccess.Configuration;
using emailApp_Q.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emailApp_Q.Server.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImportanceConfiguration());
            modelBuilder.ApplyConfiguration(new MailConfiguration());
        }

        public DbSet<Mail> Mails { get; set; }
        public DbSet<Importance> Importances { get; set; }
    }
}
