using MavenThought.Commons.Testing;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Base specification for MovieLibrary
    /// </summary>
    public abstract class MovieLibrarySpecification
        : AutoMockSpecificationWithNoContract<MovieLibrary>
    {
    }
}