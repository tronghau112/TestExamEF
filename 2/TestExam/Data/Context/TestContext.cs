using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }
    }
}