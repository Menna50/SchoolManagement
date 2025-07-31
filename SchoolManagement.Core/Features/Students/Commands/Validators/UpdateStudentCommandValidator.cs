using FluentValidation;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Students.Commands.Validators
{
    public class UpdateStudentCommandValidator:AbstractValidator<UpdateStudentCommand>
    {
        private readonly IStudentService _studentService;
        public UpdateStudentCommandValidator(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public UpdateStudentCommandValidator()
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
                .MustAsync(async (model, name, CancellationToken) => !await _studentService
                .IsNameExistExcludeSelf(name, model.Id));
        }
    }
}
