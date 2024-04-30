using FluentValidation;

namespace Cinema.Core.MoviesAggregate.Create;

public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieValidator()
    {
        RuleFor(x => x.Title).NotEmpty();        
    }
}