using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery:IRequest<Response<StudentGetByIdResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id )
        {
            Id=id;
        }
    }
}
