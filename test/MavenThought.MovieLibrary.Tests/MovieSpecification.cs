using MavenThought.Commons.Testing;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Base specification for Movie
    /// </summary>
    public abstract class MovieSpecification
        : AutoMockSpecification<Movie, IMovie>
    {
    }
}