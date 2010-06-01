using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Specification when the movie library is created
    /// </summary>
    [ConstructorSpecification]
    public class When_movie_library_is_created : MovieLibrarySpecification
    {
        /// <summary>
        /// Checks the contents are empty
        /// </summary>
        [It]
        public void Should_have_an_empty_list_of_movies()
        {
            this.Sut.Contents.Should().Be.Empty();
        }
    }
}