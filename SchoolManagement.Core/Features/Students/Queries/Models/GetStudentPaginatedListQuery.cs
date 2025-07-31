using MediatR;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Core.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery:IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber {  get; set; }
        public int PageSize { get; set; }
        public string? Search {  get; set; }
        public string[]? OrderBy { get; set; }
    }
}
