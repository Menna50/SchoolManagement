using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Maping.Students
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand,Student>().ForMember(des => des.DID
            , opt => opt.MapFrom(src => src.DepartmentId))
                ;
        }
    }
}
