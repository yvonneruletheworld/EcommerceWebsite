using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EcommerceWebsite.Data.EF
{
   public class EcommerceWebsiteContextFactory : IDesignTimeDbContextFactory<EcomWebDbContext>
    {
        public EcomWebDbContext CreateDbContext(string[] args)
        {
            //add folder hien tai la folder goc
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            var connectionString = configuration.GetConnectionString("EcommerceWebsiteDatabase");
            var optionBuilder = new DbContextOptionsBuilder<EcomWebDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new EcomWebDbContext(optionBuilder.Options);
        }
    }
}
