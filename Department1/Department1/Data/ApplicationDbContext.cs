using System;
using System.Collections.Generic;
using System.Text;
using Department1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Department1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> departments { get; set; }
        public DbSet<Supervisors> supervisors { get; set; }
        public DbSet<Workers> workers { get; set; }
        public DbSet<Profession> professions { get; set; }
    }
}
