using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotNetProject.Models
{
    public class dotNetProjectContext : DbContext
    {
        public dotNetProjectContext (DbContextOptions<dotNetProjectContext> options)
            : base(options)
        {
        }

        public DbSet<dotNetProject.Models.Department> Department { get; set; }
    }
}
