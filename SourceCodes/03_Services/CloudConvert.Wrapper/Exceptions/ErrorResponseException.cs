using System;
using System.Runtime.Serialization;
using Aliencube.CloudConvert.Wrapper.Responses;

namespace Aliencube.CloudConvert.Wrapper.Exceptions
{
    /// <summary>
    /// This represents an exception entity to be thrown when invalid format is detected.
    /// </summary>
    public class ErrorResponseException : ApplicationException
    {
        /// <summary>
        /// Initialises a new instance of the <c>ErrorResponseException</c> class.
        /// </summary>
        /// <param name="error"><c>ErrorResponse</c> object.</param>
        public ErrorResponseException(ErrorResponse error)
            : base()
        {
            this.Error = error;
        }

        /// <summary>
        /// Initialises a new instance of the <c>ErrorResponseException</c> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <param name="error"><c>ErrorResponse</c> object.</param>
        public ErrorResponseException(SerializationInfo info, StreamingContext context, ErrorResponse error)
            : base(info, context)
        {
            this.Error = error;
        }

        /// <summary>
        /// Initialises a new instance of the <c>ErrorResponseException</c> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="error"><c>ErrorResponse</c> object.</param>
        public ErrorResponseException(string message, ErrorResponse error)
            : base(message)
        {
            this.Error = error;
        }

        /// <summary>
        /// Initialises a new instance of the <c>ErrorResponseException</c> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        /// <param name="error"><c>ErrorResponse</c> object.</param>
        public ErrorResponseException(string message, Exception innerException, ErrorResponse error)
            : base(message, innerException)
        {
            this.Error = error;
        }

        /// <summary>
        /// Gets the <c>ErrorResponse</c> object.
        /// </summary>
        public ErrorResponse Error { get; private set; }
    }
}