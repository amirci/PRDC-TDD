namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Poster service implementation
    /// </summary>
    public class DummyPosterService
    {
        /// <summary>
        /// Finds the poster for the movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public string Find(IMovie movie)
        {
            return "dummy.png";
        }
    }
}