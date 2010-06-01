using System;

namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Interface for movies
    /// </summary>
    public interface IMovie
    {
        /// <summary>
        /// Title of the movie
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Release date of the movie
        /// </summary>
        DateTime? ReleaseDate { get; }
    }
}