using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Maping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, StudentGetByIdResponse>().ForMember(des => des.DepartmentName

             ,opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
