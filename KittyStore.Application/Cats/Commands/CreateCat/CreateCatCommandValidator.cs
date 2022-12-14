using FluentValidation;
using KittyStore.Domain.CatAggregate.Enums;

namespace KittyStore.Application.Cats.Commands.CreateCat
{
    public class CreateCatCommandValidator : AbstractValidator<CreateCatCommand>
    {
        public CreateCatCommandValidator()
        {
            RuleFor(c => c.Age).NotEmpty().GreaterThan(0);
            RuleFor(c => c.Breed).NotEmpty();
            RuleFor(c => c.Color).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Price).NotEmpty().GreaterThan(0);
            RuleFor(c => c.Gender).NotEmpty()
                .IsEnumName(typeof(CatGender), caseSensitive: false);
        }
    }
}