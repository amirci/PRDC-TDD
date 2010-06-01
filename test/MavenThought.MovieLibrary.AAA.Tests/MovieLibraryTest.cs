using System;
using System.Linq;
using MbUnit.Framework;
using Rhino.Mocks;

namespace MavenThought.MovieLibrary.AAA.Tests
{
    /// <summary>
    /// Test for movie library
    /// </summary>
    [TestFixture]
    public class MovieLibraryTest
    {
        /// <summary>
        /// System Under Test
        /// </summary>
        private MovieLibrary _sut;

        /// <summary>
        /// Critic to use
        /// </summary>
        private IMovieCritic _critic;

        /// <summary>
        /// Movies to add
        /// </summary>
        private IMovie _movie1;

        private IMovie _movie2;
        private IMovie _movie3;

        /// <summary>
        /// Initialize the library before each test
        /// </summary>
        [SetUp]
        public void Before_Each_Test()
        {
            _critic = MockRepository.GenerateMock<IMovieCritic>();

            // By default a dynamic mock returns false
            _movie1 = MockRepository.GenerateMock<IMovie>();
            _movie2 = MockRepository.GenerateMock<IMovie>();
            _movie3 = MockRepository.GenerateMock<IMovie>();

            _sut = new MovieLibrary(_critic);
        }

        /// <summary>
        /// The contents should be empty
        /// </summary>
        [Test]
        public void When_Initialized_Should_Be_Empty()
        {
            Assert.IsEmpty(_sut.Contents, "The contents should be empty");
        }

        /// <summary>
        /// Adding a movie should add it to the contents
        /// </summary>
        [Test]
        public void When_Adding_Should_Appear_In_The_Contents()
        {
            // Arrange
            var before = _sut.Contents.Count();

            // Act
            _sut.Add(_movie1);

            // Assert
            Assert.Contains(_sut.Contents, _movie1, "The movie should be in the contents");
            Assert.AreEqual(before + 1, _sut.Contents.Count(), "The contents should be increased by 1");
        }

        /// <summary>
        /// When a movie is added the event should notify
        /// </summary>
        [Test]
        public void When_Adding_Should_Trigger_Event()
        {
            // Create a handler to add
            var handler = MockRepository.GenerateMock<EventHandler<MovieLibraryArgs>>();

            // Add it to the library
            _sut.Added += handler;
            _sut.Add(_movie1);

            // Handler should be called with movie1 as argument
            handler.AssertWasCalled(h => h(Arg.Is(_sut),
                                           Arg<MovieLibraryArgs>
                                               .Matches(p => Equals(_movie1, p.Movie))));
        }

        /// <summary>
        /// Tests that listing non violent movies should ask the critic
        /// </summary>
        [Test]
        public void When_ListingNV_Should_Ask_Critic()
        {
            // By default a dynamic mock returns false
            // For movie1 the critic will return true
            _critic.Stub(c => c.IsViolent(_movie1)).Return(true);

            // Add the movies to the library
            _sut.Add(_movie1);
            _sut.Add(_movie2);
            _sut.Add(_movie3);

            // List NV
            _sut.ListNonViolent();

            // The critic should be called for all the movies
            _critic.AssertWasCalled(c => c.IsViolent(_movie1));
            _critic.AssertWasCalled(c => c.IsViolent(_movie2));
            _critic.AssertWasCalled(c => c.IsViolent(_movie3));
        }

        /// <summary>
        /// When listing NV should return all NV 
        /// </summary>
        [Test]
        public void When_ListingNV_Should_Return_All_NV()
        {
            // For movie1 the critic will return true
            _critic.Stub(c => c.IsViolent(_movie1)).Return(true);

            // Add the movies to the library
            _sut.Add(_movie1);
            _sut.Add(_movie2);
            _sut.Add(_movie3);

            // Get the list
            var actual = _sut.ListNonViolent();

            // assertions
            Assert.AreEqual(2, actual.Count(), "Two movies should not be violent");
            Assert.DoesNotContain(actual, _movie1, "Movie 1 should not be part of the collection");
            Assert.Contains(actual, _movie2, "Movie2 should be part of the collection");
            Assert.Contains(actual, _movie3, "Movie3 should be part of the collection");
        }

        /// <summary>
        /// When no critic exists then the library throws exception
        /// </summary>
        [Test]
        public void When_ListingNV_Should_Throw_Exception_If_Missing_Critic()
        {
            // Create the library without critic
            _sut = new MovieLibrary(null);

            Assert.Throws<MissingCriticException>(() => _sut.ListNonViolent(), "Critic Exception");
        }
    }
}