using Api.Models;
using Core.Models;
using Core.Models.Reports;
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
        public DbSet<IncomesAndExpenses> IncomesAndExpenses { get; set; } = null!;
        public DbSet<IncomesByCategory> IncomesByCategories { get; set; } = null!;
        public DbSet<ExpensesByCategory> ExpensesByCategories { get; set; } = null!;

        //use when create the database the first time -> Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<IncomesAndExpenses>().HasNoKey().ToView("vwGetIncomesAndExpenses");
            modelBuilder.Entity<IncomesByCategory>().HasNoKey().ToView("vwGetIncomesByCategory");
            modelBuilder.Entity<ExpensesByCategory>().HasNoKey().ToView("vwGetExpensesByCategory");
        }

    }
}
