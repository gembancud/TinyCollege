using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TinyCollege.Data.Models;

namespace TinyCollege.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<TinyCollegeContext>
    {
        public TinyCollegeContext CreateDbContext(string[] args)
        {
            // string environment = Environment.GetEnvironmentVariable("APP_ENVIRONMENT");
            string environment = "dev";

            string assemblyName = "TinyCollege.Data";

            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile($"settings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TinyCollegeContext>();
            var connectionString = config.GetConnectionString(nameof(TinyCollegeContext));
            optionsBuilder.UseSqlServer(connectionString, c =>
                c.MigrationsAssembly(assemblyName));
            return new TinyCollegeContext(optionsBuilder.Options);
        }
    }
}