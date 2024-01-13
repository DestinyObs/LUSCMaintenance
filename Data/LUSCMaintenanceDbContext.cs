using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LUSCMaintenance.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LUSCMaintenance.Data
{
    public class LUSCMaintenanceDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserVerification> UserVerifications { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<MaintenanceIssueCategory> MaintenanceIssueCategories { get; set; }
        public DbSet<MaintenanceIssue> MaintenanceIssues { get; set; }
        public DbSet<MaintenanceProblem> MaintenanceProblems { get; set; }

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
                new MaintenanceIssueCategory { Id = 3, Name = "Plumbing" },
                new MaintenanceIssueCategory { Id = 4, Name = "Others" }
            );
            modelBuilder.Entity<MaintenanceIssue>().HasData(
              new MaintenanceIssue { Id = 1, Description = "Faulty Socket", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 2, Description = "Broken Door", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 3, Description = "Bad Window", MaintenanceIssueCategoryId = 4 }
            );
            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin", 
                    NormalizedName = "ADMIN" 
                }
                );

            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 9,
                    UserName = "Admin@lmu.edu.ng",
                    NormalizedUserName = "ADMIN@LMU.EDU.NG",
                    Email = "Admin@lmu.edu.ng",
                    NormalizedEmail = "ADMIN@LMU.EDU.NG",
                    EmailConfirmed = true,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123", salt),
                    SecurityStamp = string.Empty,
                    Roles = "Admin",
                    IsVerified = true, // Admin is automatically verified
                    WebMail = "Admin@lmu.edu.ng"
                }
            );
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1 }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
