using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public GetStudentPaginatedListResponse(int studID, string? name, string? address, string? departmentName)
        {
            StudID = studID;
            Name = name;
            Address = address;
            DepartmentName = departmentName;
        }

        public int StudID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }

    }
}
