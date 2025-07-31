using SchoolManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.Services.Abstract
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllAsync();
        public Task<Student> GetAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> UpdateAsync(Student student);
        public Task<string> DeletAsync(Student student);
        public IQueryable< Student> GetAllQuerableAsync();
        public IQueryable<Student> FilterStudentPaginatedQuerable(string search );
    }
}
