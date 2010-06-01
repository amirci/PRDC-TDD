using System;

namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Args for movie library events
    /// </summary>
    public class MovieLibraryArgs: EventArgs
    {
        public IMovie Movie { get; set; }

        public bool Equals(MovieLibraryArgs obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.Movie, Movie);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (MovieLibraryArgs)) return false;
            return Equals((MovieLibraryArgs) obj);
        }

        public override int GetHashCode()
        {
            return Movie.GetHashCode();
        }
    }
}