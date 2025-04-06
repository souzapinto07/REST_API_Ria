//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ria.Infrastructure.Data
//{
//    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {

//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            //var configuration = new ConfigurationBuilder()
//            //    .SetBasePath(Directory.GetCurrentDirectory())
//            //    .AddJsonFile("appsettings.json")
//            //    .Build();

//            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            //var connectionString = configuration.GetConnectionString("DefaultConnection");

//            //optionsBuilder.UseNpgsql(connectionString);

//            //return new ApplicationDbContext(optionsBuilder.Options);

//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

//            optionsBuilder.UseSqlServer("Server=your-server.database.windows.net;Database=YourDbName;User Id=your-user;Password=your-password;TrustServerCertificate=True;");

//            return new ApplicationDbContext(optionsBuilder.Options);
//        }
//    }
//}
