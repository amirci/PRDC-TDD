using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Specification when ...
    /// </summary>
    [Specification]
    public class When_movie_library_is_cleared : MovieLibrarySpecification
    {
        /// <summary>
        /// Checks that no movies have been added to the library
        /// </summary>
        [It]
        public void Should_have_no_movies_in_the_library()
        {
            this.Sut.Contents.Should().Be.Empty();
        }

        /// <summary>
        /// Setup the movies
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            10.Times(() => Mock<IMovie>())
                .ForEach(movie => this.Sut.Add(movie));
        }

        /// <summary>
        /// Clear the library
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Clear();
        }
    }
}