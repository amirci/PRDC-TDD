namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Service to find posters for movies
    /// </summary>
    public interface IPosterService
    {
        /// <summary>
        /// Finds the name of the poster for movie
        /// </summary>
        /// <param name="movie">Movie to look for</param>
        /// <returns>The name of the image with the poster information</returns>
        string Find(IMovie movie);
    }
}