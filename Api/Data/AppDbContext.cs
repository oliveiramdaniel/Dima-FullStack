using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : DbContext(options)
    {
        
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        //use when create the database the first time -> Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
