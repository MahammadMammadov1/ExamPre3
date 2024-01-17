using ExamPre3.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre3.Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly DbContextOptions _dbContext;

        public AppDbContext(DbContextOptions dbContext) : base(dbContext)   
        {
            _dbContext = dbContext;
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
