using Cinema.Core.Interfaces;
using Cinema.Core.MoviesAggregate;
using Cinema.Core.MoviesAggregate.Create;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Cinema.UnitTests.MoviesAggregate;

public class CreateMovieHandlerHandle
{
    private readonly string _testTitle = "Rise of the Planet of the Apes";
    private readonly ILogger<CreateMovieHandler> _logger = Substitute.For<ILogger<CreateMovieHandler>>();
    private readonly ISpecRepository<Movie> _movieSpecRepository = Substitute.For<ISpecRepository<Movie>>();
    private CreateMovieHandler _handler;

    public CreateMovieHandlerHandle()
    {
        _handler = new CreateMovieHandler(_logger, _movieSpecRepository);
    }

    private Movie CreateMovie()
    {
        return new Movie { Title = _testTitle };
    }

    [Fact]
    public async Task ReturnsNewMovieWithGivenValidTitle()
    {
        var testMovie = CreateMovie();
        _movieSpecRepository.AddAsync(Arg.Any<Movie>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(testMovie));
        var result = await _handler.Handle(new CreateMovieCommand(_testTitle, null), CancellationToken.None);

        result.Equals(testMovie);
    }
}
