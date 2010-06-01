using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using Rhino.Mocks;
using SharpTestsEx;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Specification when listing non violent movies
    /// </summary>
    [Specification]
    public class When_movie_library_lists_non_violent_movies : MovieLibrarySpecification
    {
        /// <summary>
        /// Actual values obtained from the library
        /// </summary>
        private IEnumerable<IMovie> _actual;

        /// <summary>
        /// Expected collection of non violent movies
        /// </summary>
        private IEnumerable<IMovie> _expected;

        /// <summary>
        /// Checks the expected collection is equal to the actual
        /// </summary>
        [It]
        public void Should_return_all_the_non_violent_movies()
        {
            this._actual.Should().Have.SameSequenceAs(this._expected);
        }

        /// <summary>
        /// Setup the movies
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            var movies = 10.Times(() => Mock<IMovie>());

            this._expected = movies.Take(5).ToList();

            movies
                .Skip(5)
                .ToList()
                .ForEach(m => Dep<IMovieCritic>()
                                  .Stub(c => c.IsViolent(m))
                                  .Return(true));

            movies.ForEach(this.Sut.Add);
        }

        /// <summary>
        /// List non violent movies
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.ListNonViolent();
        }
    }
}