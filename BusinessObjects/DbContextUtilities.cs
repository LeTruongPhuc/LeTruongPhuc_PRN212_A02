using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BusinessObjects
{
    public static class DbContextUtilities
    {
        public static LucySalesDbContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LucySalesDbContext>();
            optionsBuilder.UseSqlServer(GetConnectionString());

            return new LucySalesDbContext(optionsBuilder.Options);
        }

        private static string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return config.GetConnectionString("Lucy_SalesData") ?? "";
        }
    }
}