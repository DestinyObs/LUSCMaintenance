using DotNetEnv;
using Hangfire;
using LUSCMaintenance.Data;
using LUSCMaintenance.Helpers;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using LUSCMaintenance.Repositories;
using LUSCMaintenance.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Hangfire.SqlServer;
using System.Text;

namespace LUSCMaintenance
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LUSCMaintenanceDbContext>(options =>
            {
                options.UseMySql(builder.Configuration.GetConnectionString("MyString"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MyString")));
            });

            builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;

            })
              .AddEntityFrameworkStores<LUSCMaintenanceDbContext>()
              .AddDefaultTokenProviders();
            builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

            //linking the STMP setting
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
           
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie()
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
                };

            });

            builder.Services.AddLogging();

            // Allow requests from specific origins
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSome", policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://196.13.111.164:5175", "https://196.13.111.164:5001", "https://maintenance.lmu.edu.ng:5001")
                                 .AllowAnyMethod()
                                 .AllowAnyHeader()
                                 .AllowCredentials();
                });
            });

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IMaintenanceIssueCategoryRepository, MaintenanceIssueCategoryRepository>();
            builder.Services.AddScoped<IMaintenanceIssueRepository, MaintenanceIssueRepository>();
            builder.Services.AddScoped<IMaintenanceProblemRepository, MaintenanceProblemRepository>();
            builder.Services.AddScoped<IPhotoService, PhotoService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Bearer token needed to authorize the request",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {

                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "Bearer",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http
                    },
                    new List<string>()
                }
            });

            });


            var app = builder.Build();

            // Migrate any database changes on startup (includes initial db creation)
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LUSCMaintenanceDbContext>();
                dbContext.Database.Migrate();
            }

            app.Urls.Add("https://196.13.111.164:5001"); // Using this for the server IP

            app.UseCors("AllowSome");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Endpoint routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("AllowSome"); // Apply CORS policy to controller endpoints
            });

            app.UseSwagger();
            app.UseSwaggerUI();

            // Removed the redundant app.MapControllers();

            app.Run();

        }
    }
}
