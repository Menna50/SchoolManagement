using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.InfrastructureBases;
using SchoolManagement.Infrastructure.Repositories.Interfaces;
using SchoolManagement.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _repo;
        public StudentService(IStudentRepo repo)
        {
            _repo = repo;
        }

        public async Task<string> AddAsync(Student student)
        {
            var studentWithSameName = _repo.GetTableNoTracking().Where(x => x.Name == student.Name).FirstOrDefault();
            if (studentWithSameName != null)
                return "Exist";
            await _repo.AddAsync(student);
            return "Added Successfully";
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Student> GetAsync(int id)
        {
            //    var student= await _repo.GetByIdAsync(id);
            var student =  _repo.GetTableAsTracking().Include(x => x.Department)
                .Where(x => x.StudID == id).FirstOrDefault();

            return student;
        }

        public async Task<bool> IsNameExist(string name)
        {
            var std= await _repo.GetTableAsTracking().Where(x=>x.Name.Equals(name))
                .FirstOrDefaultAsync();
            if (std == null)
                return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var std = await _repo.GetTableAsTracking().Where(x => x.Name.Equals(name)
            &&!x.StudID.Equals(id)
            )
              .FirstOrDefaultAsync();
            if (std == null)
                return false;
            return true;
        }

        public async Task<string> UpdateAsync(Student student)
        {
         await  _repo.UpdateAsync(student);
            await _repo.SaveChangesAsync();
            return "Success";
        }
        public async Task<string> DeletAsync(Student student )
        {
            await _repo.DeleteAsync(student);
      
            return "Success";
        }

        public IQueryable<Student> GetAllQuerableAsync()
        {
         return   _repo.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(string search)
        {
           var querable= _repo.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            querable = querable.Where(x=>x.Name.Contains(search)||x.Address.Contains(search));
            return querable;
        }
    }
}
