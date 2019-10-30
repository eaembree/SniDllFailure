using Microsoft.EntityFrameworkCore;

namespace EfDeploymentTest.Ef
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(builder =>
            {
                builder.ToTable("Log");
                builder.HasKey(l => l.Id);
            });
        }
    }
}
