using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasOne(t => t.Performer)
                .WithMany(g => g.Performers)
                .HasForeignKey(g => g.PerformerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TaskItem>().HasOne(t => t.Creator)
                .WithMany(g => g.Creators)
                .HasForeignKey(g => g.CreatorId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TaskItem>().Property(t => t.PerformerId).IsRequired(false);
        }
    }
}
