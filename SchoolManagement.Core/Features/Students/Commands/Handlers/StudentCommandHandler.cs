using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler
        , IRequestHandler<AddStudentCommand, Response<string>>
       , IRequestHandler<UpdateStudentCommand, Response<string>>
        , IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //  var addStudent = _mapper.Map<Student>(request);
            var ToAddStuent = new Student()
            {
                Name = request.Name,
                Phone = request.Phone,
                Address = request.Address,
                DID = request.DepartmentId,
            };
            var res = await _studentService.AddAsync(ToAddStuent);
            if (res == "Added Successfully")
                return Created("Added Successfully");
            return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var stud = await _studentService.GetAsync(request.Id);
            if (stud == null)
                return NotFound<string>("Student not found!");
            //   _mapper.Map(request,stud);
            stud.Phone = request.Phone;
            stud.Address = request.Address;
            stud.Name = request.Name;
            stud.DID = request.DepartmentId;
            var res = await _studentService.UpdateAsync(stud);
            if (res == "Success")
                return Success<string>("Success");
            return BadRequest<string>();


        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var stud = await _studentService.GetAsync(request.Id);
            if (stud == null)
                return NotFound<string>("Student not found");
            var res = await _studentService.DeletAsync(stud);
            if (res == "Success")
              return  Success<string>("Deleted successfully");
            return BadRequest<string>();

        }
    }
}
