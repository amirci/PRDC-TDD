using System;

namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Factory to create movies
    /// </summary>
    public interface IMovieFactory
    {
        /// <summary>
        /// Create the movie using the title and release time
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        IMovie Create(string key, DateTime value);
    }
}