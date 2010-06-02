using System;
using System.Collections.Generic;
using System.Linq;

namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Library to store media
    /// </summary>
    public class MovieLibrary
    {
        /// <summary>
        /// Contents of the library
        /// </summary>
        private readonly ICollection<IMovie> contents = new List<IMovie>();

        private IPosterService _posterService;

        /// <summary>
        /// Initializes a new instance of <see cref="MovieLibrary"/> class.
        /// </summary>
        /// <param name="critic">Critic to use</param>
        /// <param name="posterService">Poster service to use</param>
        public MovieLibrary(IMovieCritic critic, IPosterService posterService)
            : this(critic)
        {
            this._posterService = posterService;
        }

        public MovieLibrary(IMovieCritic critic)
        {
            // Store the critic
            this.Critic = critic;
        }

        /// <summary>
        /// Event handler to notify when a movie was added 
        /// </summary>
        public event EventHandler<MovieLibraryArgs> Added = delegate { };

        /// <summary>
        /// Gets the critics associated to the library
        /// </summary>
        protected IMovieCritic Critic { get; private set; }

        /// <summary>
        /// Gets the Contents of the library
        /// </summary>
        public IEnumerable<IMovie> Contents
        {
            get { return contents; }
        }

        /// <summary>
        /// Adds a movie to the library
        /// </summary>
        /// <param name="movie">Movie to add</param>
        public void Add(IMovie movie)
        {
            contents.Add(movie);

            this.Added(this, new MovieLibraryArgs { Movie = movie });
        }

        /// <summary>
        /// Lists non violent movies
        /// </summary>
        /// <returns>The collection of non violent movies</returns>
        public IEnumerable<IMovie> ListNonViolent()
        {
            if( Critic == null )
            {
                throw new MissingCriticException();
            }

            return this.Contents.Where(m => !this.Critic.IsViolent(m)).ToList();
        }

        /// <summary>
        /// Clear the contents
        /// </summary>
        public void Clear()
        {
            this.contents.Clear();
        }

        /// <summary>
        /// Gets the poster for the movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public string Poster(IMovie movie)
        {
            return this._posterService.Find(movie);
        }
    }
}