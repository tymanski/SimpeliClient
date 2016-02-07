using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli
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
        /// Initializes new isnatnce of SimpeliException class.
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
