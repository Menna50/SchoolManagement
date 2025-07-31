using AutoMapper;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Maping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            //  AddStudentCommandMapping();
          //  UpdateStudentCommandMapping();
        }
    }
}
