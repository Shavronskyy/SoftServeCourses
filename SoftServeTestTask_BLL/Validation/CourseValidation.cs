using FluentValidation;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_BLL.Validation
{
    public class CreateCourseValidation : AbstractValidator<CreateCourseDTO>
    {
        public CreateCourseValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        }
    }

    public class UpdateCourseValidation : AbstractValidator<UpdateCourseDTO>
    {
        public UpdateCourseValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(300).WithMessage("Description must not exceed 100 characters.");
        }
    }
}
