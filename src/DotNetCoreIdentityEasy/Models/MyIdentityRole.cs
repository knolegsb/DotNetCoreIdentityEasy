using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreIdentityEasy.Models
{
    public class MyIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
