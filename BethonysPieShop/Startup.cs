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

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IPieRepository, PieRepository>(); // AddTransient -> whenever someone ask for an instance of IPieRepository, provide a new MockPieRepository
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaule",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
