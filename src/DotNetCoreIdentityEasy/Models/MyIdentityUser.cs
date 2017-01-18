using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreIdentityEasy.Models
{
    public class MyIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
