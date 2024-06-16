using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(3, 100)
                .WithMessage("Name cannot be longer than 100 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .Length(1, 500)
                .WithMessage("Description cannot be longer than 500 characters.");

            RuleFor(dto => dto.Category)
                .NotEmpty()
                .WithMessage("Category is required.")
                .Length(1, 50)
                .WithMessage("Category cannot be longer than 50 characters.");

            RuleFor(dto => dto.City)
                .Length(1, 100)
                .WithMessage("City cannot be longer than 100 characters.");

            RuleFor(dto => dto.Street)
               .Length(5, 200)
               .WithMessage("Street cannot be longer than 200 characters.");

            RuleFor(dto => dto.PostalCode)
               .Length(3, 10)
               .WithMessage("PostalCode cannot be longer than 10 characters.");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(dto => dto.ContactNumber)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Invalid phone number format.");

        }
    }
}
