using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BethonysPieShop.Models;
using BethonysPieShop.Models.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BethonysPieShop
{
    public class Program
    {
        //1 Asp.net core app is like an console app. It has a Main method as entry point
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();

            //getting access to dependency injection container inside the Main method via the Services collection
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;//getting all services in scope
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();//getting required context
                    DbInitializer.Seed(context);
                }
                catch (Exception)
                {
                    //we could log this in a real-world situation
                }
            }

            host.Run();
        }

        //2 creating the hosting environment behind the scenes
        //this will create an internal web server(kestrel) and also the iis server
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) //CreateDefaultBuilder() will create many defaults
                .UseStartup<Startup>();
    }
}
