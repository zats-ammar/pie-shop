using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BethonysPieShop.Models.Context
{
    //a dbcontext is a middlewear between our code and db
    //when plugin aspnetcore identity, we inherit from IdentityDbContext instead of DbContext
    //this change makes possiblity to AppDbContext to work with the user types which will be automatically added by IdentityDbContext
    public class AppDbContext : IdentityDbContext<IdentityUser> //creating the properties for a default IdentityUser. If you need more properties, you can inherit IdentityUser and pass that usertype here
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
