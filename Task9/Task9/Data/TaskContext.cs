using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(t => t.Performers)
                .WithOne(g => g.Performer)
                .HasForeignKey(g => g.PerformerId);
            modelBuilder.Entity<User>().HasMany(t => t.Creators)
                .WithOne(g => g.Creator)
                .HasForeignKey(g => g.CreatorId);
        }
    }
}
