using AutoMapper;
using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Queries.Models;
using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Core.Wrapper;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Students.Queries.Handlers
{

    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<List<StudentGetListResponse>>>
        , IRequestHandler<GetStudentByIdQuery,Response<StudentGetByIdResponse>>
      , IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentQueryHandler (IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
            
        }
        public async Task<Response<List<StudentGetListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students= await  _studentService.GetAllAsync();
            var studentsMapper = _mapper.Map<List<StudentGetListResponse>>(students);
            return Success( studentsMapper);
        }

        public async Task<Response<StudentGetByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        { 
            var student=await _studentService.GetAsync(request.Id);
            if (student == null)
                return NotFound<StudentGetByIdResponse>();
            var stRes=_mapper.Map<StudentGetByIdResponse>(student);
            return Success(stRes);
        }

        public Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student,GetStudentPaginatedListResponse>> expression=
                s=>new GetStudentPaginatedListResponse(s.StudID,s.Name,s.Address,s.Department.DName);
            var querable = _studentService.GetAllQuerableAsync();
            if (request.Search!=null)
                querable = querable.Where(x => x.Name.Contains(request.Search) 
                || x.Address.Contains(request.Search));
            var paginatedResult =querable.Select(expression).ToPaginatedListAsync(request.PageNumber,request.PageSize);
            return paginatedResult;
        }
    }
}
