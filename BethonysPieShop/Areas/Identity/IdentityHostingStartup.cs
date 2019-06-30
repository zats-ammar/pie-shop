using System;
using BethonysPieShop.Models.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BethonysPieShop.Areas.Identity.IdentityHostingStartup))]
namespace BethonysPieShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        //configuring identity
        public void Configure(IWebHostBuilder builder)
        {
            //registering services for identity
            builder.ConfigureServices((context, services) =>
            {
                services.AddDefaultIdentity<IdentityUser>() //bring support for identity
                .AddEntityFrameworkStores<AppDbContext>(); //specifies that our appdbcontext is used to store identity info 
            });
        }
    }
}