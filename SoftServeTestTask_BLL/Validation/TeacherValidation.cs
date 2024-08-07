using FluentValidation;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_BLL.Validation
{
    public class CreateTeacherValidation : AbstractValidator<CreateTeacherDTO>
    {
        public CreateTeacherValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Incorrect email");
            RuleFor(x => x.Surname).NotEmpty()
                .NotEmpty().WithMessage("Surname is required")
                .MaximumLength(100).WithMessage("Surname must not exceed 100 characters.");
        }
    }

    public class UpdateTeacherValidation : AbstractValidator<UpdateTeacherDTO>
    {
        public UpdateTeacherValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Incorrect email");
            RuleFor(x => x.Surname).NotEmpty()
                .NotEmpty().WithMessage("Surname is required")
                .MaximumLength(100).WithMessage("Surname must not exceed 100 characters.");
        }
    }
}
