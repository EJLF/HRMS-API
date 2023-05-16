using HRMS_Stored_Procedure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace HRMS_Stored_Procedure.Data
{
    public class HRMSDbContext: IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }
        public ILogger _logger { get; }
        public IWebHostEnvironment _env { get; }

        public HRMSDbContext(IConfiguration appConfig, ILogger<HRMSDbContext> logger, IWebHostEnvironment env)
        {
            _appConfig = appConfig;
            _logger = logger;
            _env = env;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = _appConfig.GetConnectionString("Server");
            var db = _appConfig.GetConnectionString("DB");

            string connectionString;
            if (_env.IsDevelopment())
            {
                connectionString = $"Server={server};Database={db};MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true;";
            }
            else
            {
                var userName = _appConfig.GetConnectionString("UserName");
                var password = _appConfig.GetConnectionString("Password");
                connectionString = $"Server={server};Database={db};User Id= {userName};Password={password};MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true;";
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string is not configured.");
            }

            optionsBuilder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            })
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDefaultData();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<DepartmentPosition> DepartmentPositions { get; set; }
    }
}
