using FMS.Models.Common;
using FMS.Models.Main;
using Microsoft.EntityFrameworkCore;

namespace FMS.Services.Database
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Forklift> Forklifts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<JobStepType> JobStepTypes { get; set; }
        public DbSet<JobStep> JobSteps { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<TebConfigData> tebConfigDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forklift>()
            .HasOne(t => t.BackedUpTebConfig)
            .WithOne(f => f.Forklift)
            .HasForeignKey<TebConfigData>(t => t.ForkliftId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
