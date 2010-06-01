using System;

namespace MavenThought.MovieLibrary
{
    /// <summary>
    /// Exception when the critic is missing
    /// </summary>
    public class MissingCriticException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception" /> class.
        /// </summary>
        public MissingCriticException()
            : this("Call 911! The critic is missing!")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Exception" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MissingCriticException(string message) : base(message)
        {
        }
    }
}