﻿// <auto-generated />
using System;
using LUSCMaintenance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LUSCMaintenance.Migrations
{
    [DbContext(typeof(LUSCMaintenanceDbContext))]
    [Migration("20240131181039_marrymeee")]
    partial class marrymeee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LUSCMaintenance.Models.MaintenanceIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaintenanceIssueCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceIssueCategoryId");

                    b.ToTable("MaintenanceIssues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Faulty Socket",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Broken Door Handle",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Bad Window",
                            MaintenanceIssueCategoryId = 4
                        },
                        new
                        {
                            Id = 4,
                            Description = "Broken Door",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Faulty Switch",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Faulty Ceiling Fan",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 7,
                            Description = "Bad Ceiling Fan Blade",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 8,
                            Description = "Faulty Fan Regulator",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 9,
                            Description = "Faulty Bulbs(ROOM)",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 10,
                            Description = "Fault Bulbs(LOBBY)",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 11,
                            Description = "DSTV Decoder",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 12,
                            Description = "Security Lights",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 13,
                            Description = "Room Keys",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 14,
                            Description = "Wardrobe",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 15,
                            Description = "Wardrobe Catcher",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 16,
                            Description = "Reading Table",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 17,
                            Description = "Faulty Distribution Box",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 18,
                            Description = "Reading Chair",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 19,
                            Description = "Metal Bunk",
                            MaintenanceIssueCategoryId = 4
                        },
                        new
                        {
                            Id = 20,
                            Description = "Window Net",
                            MaintenanceIssueCategoryId = 4
                        },
                        new
                        {
                            Id = 21,
                            Description = "Curtain Railing",
                            MaintenanceIssueCategoryId = 4
                        },
                        new
                        {
                            Id = 22,
                            Description = "Ceiling PVC",
                            MaintenanceIssueCategoryId = 1
                        },
                        new
                        {
                            Id = 23,
                            Description = "Wardrobe Handle",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 24,
                            Description = "Toilet Door",
                            MaintenanceIssueCategoryId = 2
                        },
                        new
                        {
                            Id = 25,
                            Description = "Water Reservoir Drum",
                            MaintenanceIssueCategoryId = 3
                        },
                        new
                        {
                            Id = 26,
                            Description = "Wash Hand Basin",
                            MaintenanceIssueCategoryId = 3
                        },
                        new
                        {
                            Id = 27,
                            Description = "Taps",
                            MaintenanceIssueCategoryId = 3
                        },
                        new
                        {
                            Id = 28,
                            Description = "Water Closet",
                            MaintenanceIssueCategoryId = 3
                        },
                        new
                        {
                            Id = 29,
                            Description = "Washing Bowl",
                            MaintenanceIssueCategoryId = 3
                        },
                        new
                        {
                            Id = 30,
                            Description = "Washing Bowl",
                            MaintenanceIssueCategoryId = 3
                        },
                        new
                        {
                            Id = 31,
                            Description = "Shower ",
                            MaintenanceIssueCategoryId = 3
                        },
                        new
                        {
                            Id = 32,
                            Description = "Extractor Fan",
                            MaintenanceIssueCategoryId = 3
                        },
                        new
                        {
                            Id = 33,
                            Description = "Cloth lines",
                            MaintenanceIssueCategoryId = 4
                        },
                        new
                        {
                            Id = 34,
                            Description = "Waste Bin",
                            MaintenanceIssueCategoryId = 4
                        },
                        new
                        {
                            Id = 35,
                            Description = "Duct Cover",
                            MaintenanceIssueCategoryId = 4
                        },
                        new
                        {
                            Id = 36,
                            Description = "Door Frame",
                            MaintenanceIssueCategoryId = 2
                        });
                });

            modelBuilder.Entity("LUSCMaintenance.Models.MaintenanceIssueCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MaintenanceIssueCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electrical Maintenance"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Carpentry Maintenance"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Plumbing Maintenance"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Others Maintenance"
                        });
                });

            modelBuilder.Entity("LUSCMaintenance.Models.MaintenanceProblem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateComplaintMade")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Hostel")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeAvailable")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("WebMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MaintenanceProblems");
                });

            modelBuilder.Entity("LUSCMaintenance.Models.MaintenanceProblemIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceIssueId")
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceProblemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceIssueId");

                    b.HasIndex("MaintenanceProblemId");

                    b.ToTable("MaintenanceProblemIssue");
                });

            modelBuilder.Entity("LUSCMaintenance.Models.PasswordReset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ResetToken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResets");
                });

            modelBuilder.Entity("LUSCMaintenance.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int?>("UserVerificationId")
                        .HasColumnType("int");

                    b.Property<string>("WebMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("UserVerificationId")
                        .IsUnique();

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2bc2b471-4b12-4408-8384-928c765bd290",
                            Email = "hor@lmu.edu.ng",
                            EmailConfirmed = true,
                            IsVerified = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "HOR@LMU.EDU.NG",
                            NormalizedUserName = "HOR@LMU.EDU.NG",
                            PasswordHash = "$2a$10$dsFG3LreqzY8qtO8QZ5ru.JQY/hB/4eqDk2IksIKRjJt0YOlWeyrq",
                            PhoneNumberConfirmed = false,
                            Roles = "Admin",
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "HOR",
                            WebMail = "hor@lmu.edu.ng"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "acb96e68-49df-4a37-b3ad-6aa3c95b8a79",
                            Email = "vcm@lmu.edu.ng",
                            EmailConfirmed = true,
                            IsVerified = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "VCM@LMU.EDU.NG",
                            NormalizedUserName = "VCM@LMU.EDU.NG",
                            PasswordHash = "$2a$10$dsFG3LreqzY8qtO8QZ5ru.2vBMiKggO7tc4..Qn4CdaV7IuPfHZxK",
                            PhoneNumberConfirmed = false,
                            Roles = "Admin",
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "VCM",
                            WebMail = "vcm@lmu.edu.ng"
                        });
                });

            modelBuilder.Entity("LUSCMaintenance.Models.UserVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VerificationToken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserVerifications");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LUSCMaintenance.Models.MaintenanceIssue", b =>
                {
                    b.HasOne("LUSCMaintenance.Models.MaintenanceIssueCategory", "MaintenanceIssueCategory")
                        .WithMany()
                        .HasForeignKey("MaintenanceIssueCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintenanceIssueCategory");
                });

            modelBuilder.Entity("LUSCMaintenance.Models.MaintenanceProblemIssue", b =>
                {
                    b.HasOne("LUSCMaintenance.Models.MaintenanceIssue", "MaintenanceIssue")
                        .WithMany("MaintenanceProblemIssues")
                        .HasForeignKey("MaintenanceIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LUSCMaintenance.Models.MaintenanceProblem", "MaintenanceProblem")
                        .WithMany("MaintenanceProblemIssues")
                        .HasForeignKey("MaintenanceProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintenanceIssue");

                    b.Navigation("MaintenanceProblem");
                });

            modelBuilder.Entity("LUSCMaintenance.Models.PasswordReset", b =>
                {
                    b.HasOne("LUSCMaintenance.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LUSCMaintenance.Models.User", b =>
                {
                    b.HasOne("LUSCMaintenance.Models.UserVerification", "UserVerification")
                        .WithOne("User")
                        .HasForeignKey("LUSCMaintenance.Models.User", "UserVerificationId");

                    b.Navigation("UserVerification");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("LUSCMaintenance.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("LUSCMaintenance.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LUSCMaintenance.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("LUSCMaintenance.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LUSCMaintenance.Models.MaintenanceIssue", b =>
                {
                    b.Navigation("MaintenanceProblemIssues");
                });

            modelBuilder.Entity("LUSCMaintenance.Models.MaintenanceProblem", b =>
                {
                    b.Navigation("MaintenanceProblemIssues");
                });

            modelBuilder.Entity("LUSCMaintenance.Models.UserVerification", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
