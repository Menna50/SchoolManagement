using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Data.Entities;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Core.Bases;


namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<StudentGetListResponse>>>
    {

    }
}
