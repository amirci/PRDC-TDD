
namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Critic for movies
    /// </summary>
    public interface IMovieCritic
    {
        /// <summary>
        /// Gets the violence amount for a movie
        /// </summary>
        /// <param name="movie">Movie to be reviewed</param>
        /// <returns>True if the movie is violent, false otherwise</returns>
        bool IsViolent(IMovie movie);
    }
}