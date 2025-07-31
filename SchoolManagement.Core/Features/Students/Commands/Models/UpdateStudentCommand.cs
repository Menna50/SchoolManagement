using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Students.Commands.Models
{
    public class UpdateStudentCommand: IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public string Address { get; set; }

        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
    }
}
