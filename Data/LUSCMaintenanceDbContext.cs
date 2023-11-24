using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LUSCMaintenance.Models;

namespace LUSCMaintenance.Data
{
    public class LUSCMaintenanceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserVerification> UserVerifications { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<MaintenanceIssueCategory> MaintenanceIssueCategories { get; set; }

        public LUSCMaintenanceDbContext(DbContextOptions<LUSCMaintenanceDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserVerification)
                .WithOne(uv => uv.User)
                .HasForeignKey<User>(u => u.UserVerificationId)
                .IsRequired(false);
            modelBuilder.Entity<PasswordReset>()
                .HasOne(pr => pr.User)
                .WithMany()
                .HasForeignKey(pr => pr.UserId)
                .IsRequired();

            // Seed Maintenance Issue Categories
            modelBuilder.Entity<MaintenanceIssueCategory>().HasData(
                new MaintenanceIssueCategory { Id = 1, Name = "Electrical Maintenance" },
                new MaintenanceIssueCategory { Id = 2, Name = "Carpentry" },
                new MaintenanceIssueCategory { Id = 3, Name = "Plumbing" }
            );


            base.OnModelCreating(modelBuilder);
        }


    }
}