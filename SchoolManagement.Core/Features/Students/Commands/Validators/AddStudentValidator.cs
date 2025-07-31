using FluentValidation;
using SchoolManagement.Data.Entities;
using SchoolManagement.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Students.Commands.Validators
{
   
    public class AddStudentValidator:AbstractValidator<Student>
    {
        private readonly IStudentService _studentService;
        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public AddStudentValidator()
        {
            applyValidationRules();
            applyCustomValidationRules();
        }
       protected void applyValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(10).WithMessage("Max length is 10");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address must not be empty")
                .NotNull().WithMessage("Email must not be  null")
                .MaximumLength(10).WithMessage("Max length is 10");
        }
        protected void applyCustomValidationRules()
        {
            RuleFor(x => x.Name)
               .MustAsync(async (Name, CancellationToken) =>  !await _studentService.IsNameExist(Name))
                .WithMessage("Name is exist!");

        }
    }


}
