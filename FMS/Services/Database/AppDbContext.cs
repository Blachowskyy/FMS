using FMS.Models.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
