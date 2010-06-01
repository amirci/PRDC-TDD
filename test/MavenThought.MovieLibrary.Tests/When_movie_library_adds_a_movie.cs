using System;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using Rhino.Mocks;
using SharpTestsEx;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Specification when adding a movie to the library
    /// </summary>
    [Specification]
    public class When_movie_library_adds_a_movie : MovieLibrarySpecification
    {
        /// <summary>
        /// Movie to use
        /// </summary>
        private IMovie _movie;

        /// <summary>
        /// Handler to use
        /// </summary>
        private EventHandler<MovieLibraryArgs> _handler;

        /// <summary>
        /// Checks the movie has been added
        /// </summary>
        [It]
        public void Should_include_the_movie()
        {
            this.Sut.Contents.Should().Have.SameSequenceAs(Enumerable.Create(this._movie));
        }

        /// <summary>
        /// Check the handler is called
        /// </summary>
        [It]
        public void Should_notify_an_element_was_added()
        {
            this._handler.AssertWasCalled(h => h(Arg.Is(this.Sut), Arg<MovieLibraryArgs>.Matches(arg => arg.Movie == this._movie)));
        }

        /// <summary>
        /// Setup the movie
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._movie = MockIt(this._movie);

            this._handler = MockIt(this._handler);
        }

        /// <summary>
        /// Register the handler
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this.Sut.Added += this._handler;
        }

        /// <summary>
        /// Add the movie
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Add(this._movie);
        }
    }
}