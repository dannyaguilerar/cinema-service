using FluentValidation;

namespace Cinema.Core.TheatersAggregate.Create;

public class CreateTheaterValidator : AbstractValidator<CreateTheaterCommand>
{
    public CreateTheaterValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
