using FluentValidation;
using FortressAuth.Application.DTOs.User;

namespace FortressAuth.Application.Validators.User
{
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(createUserDTO => createUserDTO.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(createUserDTO => createUserDTO.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(createUserDTO => createUserDTO.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$"); // At least one uppercase letter, one lowercase letter, and one digit
        }
    }
}
