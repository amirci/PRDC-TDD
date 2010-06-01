using MavenThought.Commons.Testing;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Specification when listing non violent movies with no critic
    /// </summary>
    [ExceptionSpecification]
    public class When_movie_library_list_non_violent_with_no_critic : MovieLibrarySpecification
    {
        /// <summary>
        /// Check the missing critic exception is thrown
        /// </summary>
        [It]
        public void Should_throw_missing_critic_exception()
        {
            AssertExceptionThrown<MissingCriticException>();
        }

        /// <summary>
        /// Create the movie library with no critic
        /// </summary>
        /// <returns>A new instance of the movie library</returns>
        protected override MovieLibrary CreateSut()
        {
            return new MovieLibrary(null);
        }

        /// <summary>
        /// Get non violent movies
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.ListNonViolent();
        }
    }
}