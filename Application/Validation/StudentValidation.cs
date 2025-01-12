using Domain.DTOs.StudentDTOs;
using FluentValidation;

namespace Application.Validation
{
    public class StudentValidation : AbstractValidator<CreateStudentDTO>
    {
        public StudentValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.FatherName)
                .NotEmpty().WithMessage("Father's Name is required.")
                .MaximumLength(50).WithMessage("Father's Name must not exceed 50 characters.");

            RuleFor(x => x.MotherName)
                .NotEmpty().WithMessage("Mother's Name is required.")
                .MaximumLength(50).WithMessage("Mother's Name must not exceed 50 characters.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .Must(g => g == "Male" || g == "Female" || g == "Other")
                .WithMessage("Gender must be Male, Female, or Other.");

            RuleFor(x => x.DoB)
                .NotEmpty().WithMessage("Date of Birth is required.")
                .LessThan(DateTime.Today).WithMessage("Date of Birth must be in the past.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.Faculty)
                .NotEmpty().WithMessage("Faculty is required.");

            RuleFor(x => x.Semester)
                .NotEmpty().WithMessage("Semester is required.");

            RuleFor(x => x.PhoneNo)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Invalid phone number format.");
        }
    }
}
