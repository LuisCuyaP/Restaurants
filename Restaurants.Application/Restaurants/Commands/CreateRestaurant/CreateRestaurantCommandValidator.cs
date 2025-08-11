using FluentValidation;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Chinese", "Indian", "French", "Japanese"];
    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 100)
            .WithMessage("Name must be between 3 and 100 characters.");

        RuleFor(x => x.Category)
            .Must(validCategories.Contains)
            .WithMessage("Invalid category. Please choose a valid category.");
/*             .Custom((value, context) =>
            {

                var isValidCategory = validCategories.Contains(value);
                if (!isValidCategory)
                {
                    context.AddFailure("Category", $"Category must be one of the following: {string.Join(", ", validCategories)}.");
                }
                
            });
 */

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required.");

        RuleFor(x => x.ContactEmail)
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(x => x.Street)
            .NotEmpty()
            .WithMessage("Street is required.");

        RuleFor(x => x.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Invalid PostalCode format.");
    }
}