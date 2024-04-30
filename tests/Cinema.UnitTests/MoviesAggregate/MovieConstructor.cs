using Cinema.Core.MoviesAggregate;

namespace Cinema.UnitTests.MoviesAggregate;

public class MovieConstructor
{
    private readonly string _testTitle = "Rise of the Planet of the Apes";
    private Movie? _testMovie;

    public Movie CreateMovie()
    {
        return new Movie { Title = _testTitle };
    }

    [Fact]
    public void InitializesTitle()
    {
        _testMovie = CreateMovie();
        Assert.Equal(_testTitle, _testMovie.Title);
    }
}