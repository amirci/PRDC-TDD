using System;

namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Implementation for movie
    /// </summary>
    public class Movie : IMovie
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="releaseDate"></param>
        public Movie(string title, DateTime? releaseDate)
        {
            this.Title = title;
            this.ReleaseDate = releaseDate;
        }

        /// <summary>
        /// Title of the movie
        /// </summary>
        public string Title
        {
            get; private set;
        }

        /// <summary>
        /// Release date of the movie
        /// </summary>
        public DateTime? ReleaseDate
        {
            get; private set;
        }
    }
}