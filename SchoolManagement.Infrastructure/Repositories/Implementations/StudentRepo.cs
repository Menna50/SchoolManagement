using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.InfrastructureBases;
using SchoolManagement.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories.Implementations
{
    public class StudentRepo :GenericRepo<Student>, IStudentRepo
    {
    private readonly DbSet<Student> _students;
        public StudentRepo(AppDbContext context):base(context)
        {
            _students = context.Students;
        }
        public async Task<List<Student>> GetAllAsync()
        {
            return await _students.Include(x=>x.Department).ToListAsync();
        }
    }
}
