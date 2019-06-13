using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethonysPieShop.Models;
using BethonysPieShop.Models.Context;
using BethonysPieShop.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BethonysPieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        //aspnetcore automatically reads our configs(e.g appsetting.json) via program.cs-> CreateDefaultBuilder
        //those configs are available in the app via IConfiguration
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //3 configure build in and our own custom service here
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IPieRepository, PieRepository>(); // AddTransient -> whenever someone ask for an instance of IPieRepository, provide a new MockPieRepository
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddMvc(); //enabling MVC for this application
        }

        //4 setup the request pipeline
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //configure middleware components here
            //sequence of adding them is important
            app.UseDeveloperExceptionPage(); //to get the yellow colour exception page
            app.UseStatusCodePages(); //show the status of the responses
            app.UseStaticFiles(); //support(search/get) for static files which are in wwwroot folder
            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();// this should be added after UseStaticFiles()

            app.UseMvc(routes =>
            {
                //since Index action in Home controller is default, url will not show these segments
                routes.MapRoute(
                    name: "defaule",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
