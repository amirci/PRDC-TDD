using System;
using System.Linq;
using MbUnit.Framework;
using Rhino.Mocks;

namespace MavenThought.MovieLibrary.xUnit.Tests
{
    /// <summary>
    /// Test for movie library
    /// </summary>
    [TestFixture]
    public class MovieLibraryTest
    {
        private MockRepository _mockery;

        private MovieLibrary _library;

        private IMovieCritic _critic;

        /// <summary>
        /// Initialize the repository and library
        /// </summary>
        [SetUp]
        public void BeforeEachTest()
        {
            this._mockery = new MockRepository();
            this._critic = _mockery.StrictMock<IMovieCritic>();
            this._library = new MovieLibrary(this._critic);
        }

        /// <summary>
        /// Run after each test
        /// </summary>
        [TearDown]
        public void AfterEachTest()
        {
            this._library.Clear();    
        }

        /// <summary>
        /// Checks when the library is created
        /// </summary>
        [Test]
        public void WhenTheLibraryIsCreatedTheContentShouldBeEmpty()
        {
            Assert.IsEmpty(_library.Contents);
        }

        /// <summary>
        /// Checks the contents
        /// </summary>
        [Test]
        public void WhenAMovieIsAddedThenShouldAppearInTheContents()
        {
            var movie = _mockery.StrictMock<IMovie>();

            using (_mockery.Record())
            {
                // no expectations
            }

            using (_mockery.Playback() )
            {
                var before = _library.Contents.Count();
                _library.Add(movie);
                Assert.Contains(_library.Contents, movie);
                Assert.AreEqual(before + 1, _library.Contents.Count());
            }

        }

        /// <summary>
        /// Checks non violent movies
        /// </summary>
        [Test]
        public void WhenListingNonViolentMoviesTheCriticShouldBeAsked()
        {
            this._library = new MovieLibrary(_critic);

            var movie1 = _mockery.StrictMock<IMovie>();
            var movie2 = _mockery.StrictMock<IMovie>();
            var movie3 = _mockery.StrictMock<IMovie>();

            using (_mockery.Record())
            {
                SetupResult.For(_critic.IsViolent(movie1)).Return(true);
                SetupResult.For(_critic.IsViolent(movie2)).Return(false);
                SetupResult.For(_critic.IsViolent(movie3)).Return(false);
            }

            using (_mockery.Playback())
            {
                _library.Add(movie1);
                _library.Add(movie2);
                _library.Add(movie3);
                var actual = _library.ListNonViolent();

                Assert.AreEqual(2, actual.Count());
                Assert.DoesNotContain(actual, movie1);
                Assert.Contains(actual, movie2);
                Assert.Contains(actual, movie3);
            }
        }

        /// <summary>
        /// Checks the exception
        /// </summary>
        [Test]
        [ExpectedException(typeof( NotImplementedException ), "Critic Exception")]
        public void WhenListingNonViolentWeShouldNotGetACriticException()
        {
            this._library = new MovieLibrary(_critic);

            var movie = _mockery.StrictMock<IMovie>();

            using( _mockery.Record() )
            {
                SetupResult.For(_critic.IsViolent(null))
                    .IgnoreArguments()
                    .Throw(new NotImplementedException("Critic Exception"));
            }

            using( _mockery.Playback())
            {
                _library.Add(movie);

                var actual = _library.ListNonViolent();

                Assert.IsTrue(actual.Count( ) > 0, "The collection should be empty");
            }
        }

        /// <summary>
        /// Checks added event
        /// </summary>
        [Test]
        public void WhenAddingAMovieTheAddedEventShouldBeTriggered()
        {
            var handler = _mockery.StrictMock<EventHandler<MovieLibraryArgs>>();

            var movie = _mockery.StrictMock<IMovie>();

            using (_mockery.Record())
            {
                handler(_library, new MovieLibraryArgs {Movie = movie});
            }

            using (_mockery.Playback())
            {
                _library.Added += handler;
                _library.Add( movie );
            }
        }
    }
}