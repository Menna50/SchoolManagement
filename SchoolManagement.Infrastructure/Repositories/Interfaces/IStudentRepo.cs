using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories.Interfaces
{
    public interface IStudentRepo:IGenericRepo<Student>
    {
        public Task<List<Student>> GetAllAsync(); 
    }
}
