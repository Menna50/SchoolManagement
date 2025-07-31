using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
       public DbSet<Student> Students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }  
        public DbSet<DepartmetSubject> departmetSubjects { get; set;}
    }

}
