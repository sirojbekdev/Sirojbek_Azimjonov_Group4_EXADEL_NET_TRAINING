using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public virtual DbSet<Models.Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>().HasOne(t => t.Performer)
                .WithMany(g => g.Performers)
                .HasForeignKey(g => g.PerformerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Models.Task>().HasOne(t => t.Creator)
                .WithMany(g => g.Creators)
                .HasForeignKey(g => g.CreatorId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Models.Task>().Property(t => t.PerformerId).IsRequired(false);
        }
    }
}
