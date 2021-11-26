using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DB.Repository
{
    class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile(Directory.GetCurrentDirectory() + @"/../API/appsettings.json").Build();
            
            var builder = new DbContextOptionsBuilder<Context>();
            var connectionString = configuration["SQLConnection"];
            Console.WriteLine($"Using connection: {connectionString}");

            builder.UseSqlServer(connectionString);
            
            return new Context(builder.Options);
        }
    }
}