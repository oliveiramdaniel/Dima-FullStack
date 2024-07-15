using Api.Models;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : IdentityDbContext<
            User, //AspNetUsers
            IdentityRole<long>, //AspNetRoles (AspNetUserRoles)
            long,
            IdentityUserClaim<long>, //AspNetUserClaims
            IdentityUserRole<long>, //AspNetUserRoles
            IdentityUserLogin<long>, //AspNetUserLogins
            IdentityRoleClaim<long>, //AspNetRoleClaims
            IdentityUserToken<long> //AspNetUserTokens
            >
        (options)
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
