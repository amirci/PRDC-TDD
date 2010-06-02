using MavenThought.Commons.Testing;
using Rhino.Mocks;
using SharpTestsEx;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Specification when finding the poster
    /// </summary>
    [Specification]
    public class When_movie_library_finds_poster : MovieLibrarySpecification
    {
        private IMovie _movie;
        private string _actual;
        private string _expected;

        /// <summary>
        /// Setup the movie
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._movie = Mock<IMovie>();

            this._expected = "Blazing Saddles.png";

            this.Dep<IPosterService>()
                .Stub(srv => srv.Find(this._movie))
                .Return(_expected);
        }

        /// <summary>
        /// Checks the poster matches the expected
        /// </summary>
        [It]
        public void Should_have_the_expected_poster()
        {
            this._actual.Should().Be.EqualTo(this._expected);
        }

        /// <summary>
        /// Add the movie to the library
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this.Sut.Add(this._movie);
        }

        /// <summary>
        /// Get the poster for the movie
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.Poster(this._movie);
        }
    }
}