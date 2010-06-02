using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using Rhino.Mocks;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Specification when ...
    /// </summary>
    [Specification]
    public class When_movie_library_imports_movies : MovieLibrarySpecification
    {
        /// <summary>
        /// Movies to be imported
        /// </summary>
        private IDictionary<string, DateTime> _movies;

        /// <summary>
        /// Expected result
        /// </summary>
        private IEnumerable<IMovie> _expected;

        /// <summary>
        /// Checks that all the movies are in the library contents
        /// </summary>
        [It]
        public void Should_have_all_the_movies()
        {
            this.Sut.Contents
                .Should()
                .Have
                .SameSequenceAs(this._expected);
        }

        /// <summary>
        /// Setup the movies to add to the library
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._movies = new Dictionary<string, DateTime>
                               {
                                   { "Blazing Saddles", new DateTime(1974, 02, 7) },
                                   { "Young Frankestein", new DateTime(1974, 12, 15) },
                                   { "Spaceballs", new DateTime(1987, 06, 24) }
                               };

            this._expected = 3.Times(() => Mock<IMovie>());

            var i = 0;

            this._movies
                .ForEach(pair => Dep<IMovieFactory>()
                                     .Stub(factory => factory.Create(pair.Key, pair.Value))
                                     .Return(this._expected.ToList()[i++]));
            
        }

        /// <summary>
        /// Import the movies
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Import(this._movies);
        }
    }
}