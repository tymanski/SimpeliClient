using System;

namespace Simpeli.Responses
{
    /// <summary>
    /// An Exception wrapper class. It is thrown by SimpeliClient when an error is returned by Simpeli API. 
    /// It contains details of error stored in Error property.
    /// </summary>
    public class SimpeliException : Exception
    {
        /// <summary>
        /// Details of error returned by API.
        /// </summary>
        public ErrorResponse Error { get; private set; }

        /// <summary>
        /// Initializes new instance of SimpeliException class.
        /// </summary>
        /// <param name="statusCode">A HTTP status code read from the response from API.</param>
        /// <param name="data">Data from the response.</param>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public SimpeliException(int statusCode, string data, string message = null, Exception innerException = null) 
            : base(message, innerException)
        {
            Error = new ErrorResponse() { StatusCode = statusCode, Data = data };
        }
        
    }
}
