using DotNetCoreIdentityEasy.Models;
using DotNetCoreIdentityEasy.Models.BlogModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreIdentityEasy.Data
{
    public class MyIdentityDbContext:IdentityDbContext<MyIdentityUser, MyIdentityRole, string>
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : base(options)
        {
            //nothing here
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
