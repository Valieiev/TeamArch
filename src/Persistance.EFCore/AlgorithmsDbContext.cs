using Microsoft.EntityFrameworkCore;
using Persistence.EFСore;

namespace Persistence.EFCore
{
    public class AlgorithmsDbContext : DbContext
    {
        public AlgorithmsDbContext(DbContextOptions<AlgorithmsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserTask> UserTasks { get; set; }
        public virtual DbSet<Diagramm> Diagramms { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<CodePart> CodeParts { get; set; }
        public virtual DbSet<TestResult> TestResults { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTask>()
                .HasMany(c => c.CodeParts)
                .WithOne(e => e.UserTask);
            modelBuilder.Entity<UserTask>()
                .HasMany(c => c.Questions)
                .WithOne(e => e.UserTask);
            modelBuilder.Entity<Diagramm>()
                .HasOne(c => c.UserTask)
                .WithOne(e => e.diagramm)
                .HasForeignKey<Diagramm>(b=>b.UserTaskId);
        }
    }
}