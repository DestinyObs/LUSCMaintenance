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
                new MaintenanceIssueCategory { Id = 2, Name = "Carpentry Maintenance" },
                new MaintenanceIssueCategory { Id = 3, Name = "Plumbing Maintenance" },
                new MaintenanceIssueCategory { Id = 4, Name = "Others Maintenance" }
            );
            modelBuilder.Entity<MaintenanceIssue>().HasData(
              new MaintenanceIssue { Id = 1, Description = "Faulty Socket", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 2, Description = "Broken Door Handle", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 3, Description = "Bad Window", MaintenanceIssueCategoryId = 4 },
              new MaintenanceIssue { Id = 4, Description = "Broken Door", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 5, Description = "Faulty Switch", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 6, Description = "Faulty Ceiling Fan", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 7, Description = "Bad Ceiling Fan Blade", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 8, Description = "Faulty Fan Regulator", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 9, Description = "Faulty Bulbs(ROOM)", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 10, Description = "Fault Bulbs(LOBBY)", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 11, Description = "DSTV Decoder", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 12, Description = "Security Lights", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 13, Description = "Room Keys", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 14, Description = "Wardrobe", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 15, Description = "Wardrobe Catcher", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 16, Description = "Reading Table", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 17, Description = "Faulty Distribution Box", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 18, Description = "Reading Chair", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 19, Description = "Metal Bunk", MaintenanceIssueCategoryId = 4 },
              new MaintenanceIssue { Id = 20, Description = "Window Net", MaintenanceIssueCategoryId = 4 },
              new MaintenanceIssue { Id = 21, Description = "Curtain Railing", MaintenanceIssueCategoryId = 4 },
              new MaintenanceIssue { Id = 22, Description = "Ceiling PVC", MaintenanceIssueCategoryId = 1 },
              new MaintenanceIssue { Id = 23, Description = "Wardrobe Handle", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 24, Description = "Toilet Door", MaintenanceIssueCategoryId = 2 },
              new MaintenanceIssue { Id = 25, Description = "Water Reservoir Drum", MaintenanceIssueCategoryId = 3 },
              new MaintenanceIssue { Id = 26, Description = "Wash Hand Basin", MaintenanceIssueCategoryId = 3 },
              new MaintenanceIssue { Id = 27, Description = "Taps", MaintenanceIssueCategoryId = 3 },
              new MaintenanceIssue { Id = 28, Description = "Water Closet", MaintenanceIssueCategoryId = 3 },
              new MaintenanceIssue { Id = 29, Description = "Washing Bowl", MaintenanceIssueCategoryId = 3 },
              new MaintenanceIssue { Id = 30, Description = "Washing Bowl", MaintenanceIssueCategoryId = 3 },
              new MaintenanceIssue { Id = 31, Description = "Shower ", MaintenanceIssueCategoryId = 3 },
              new MaintenanceIssue { Id = 32, Description = "Extractor Fan", MaintenanceIssueCategoryId = 3 },
              new MaintenanceIssue { Id = 33, Description = "Cloth lines", MaintenanceIssueCategoryId = 4 },
              new MaintenanceIssue { Id = 34, Description = "Waste Bin", MaintenanceIssueCategoryId = 4 },
              new MaintenanceIssue { Id = 35, Description = "Duct Cover", MaintenanceIssueCategoryId = 4 },
              new MaintenanceIssue { Id = 36, Description = "Door Frame", MaintenanceIssueCategoryId = 2 }
            );

            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin", 
                    NormalizedName = "ADMIN" 
                },
                 new IdentityRole<int>
                 {
                     Id = 2,
                     Name = "Student",
                     NormalizedName = "STUDENT"
                 }
                );

            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "HOR",
                    NormalizedUserName = "HOR@LMU.EDU.NG",
                    Email = "hor@lmu.edu.ng",
                    NormalizedEmail = "HOR@LMU.EDU.NG",
                    EmailConfirmed = true,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Hor@123LMU", salt),
                    SecurityStamp = string.Empty,
                    Roles = "Admin",
                    IsVerified = true, // Admin is automatically verified
                    WebMail = "hor@lmu.edu.ng"
                }
            );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1}
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    UserName = "VCM",
                    NormalizedUserName = "VCM@LMU.EDU.NG",
                    Email = "vcm@lmu.edu.ng",
                    NormalizedEmail = "VCM@LMU.EDU.NG",
                    EmailConfirmed = true,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Vcm@123LMU", salt),
                    SecurityStamp = string.Empty,
                    Roles = "Admin",
                    IsVerified = true, // Admin is automatically verified
                    WebMail = "vcm@lmu.edu.ng"
                }
            );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 2 }
            );



            base.OnModelCreating(modelBuilder);
        }
    }
}
