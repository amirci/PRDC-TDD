using System;
using System.Collections.Generic;
using MbUnit.Framework;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MovieLibrary.Tests
{
    /// <summary>
    /// Specification when ...
    /// </summary>
    [ConstructorSpecification]
    public class When_movie_is_created : MovieSpecification
    {
        /// <summary>
        /// Expected title
        /// </summary>
        private readonly string _title;

        private readonly DateTime _releaseDate;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        public When_movie_is_created(
            [RandomStrings(Count=5, Pattern="The great [A-Za-z]{8}")]string title,
                [MbUnit.Framework.Factory("RandomDates")]DateTime releaseDate)
        {
            this._title = title;
            this._releaseDate = releaseDate;
        }

        /// <summary>
        /// Checks the title is the expected one
        /// </summary>
        [It]
        public void Should_have_the_same_title()
        {
            this.Sut.Title.Should().Be.EqualTo(this._title);
        }

        /// <summary>
        /// Checks the release date is the expected one
        /// </summary>
        [It]
        public void Should_have_the_same_release_date()
        {
            this.Sut.ReleaseDate.Should().Be.EqualTo(this._releaseDate);
        }

        /// <summary>
        /// Creates the movie
        /// </summary>
        /// <returns></returns>
        protected override IMovie CreateSut()
        {
            return new Movie(this._title, this._releaseDate);
        }

        /// <summary>
        /// Factory for random dates
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<DateTime> RandomDates()
        {
            for (var i = 0; i < 5; i++)
            {
                yield return DateTime.Now.AddDays(i);
            }
        }
    }
}