namespace Simpeli.Responses
{
    /// <summary>
    /// Class representing error response from the API.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Response status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Data sent in the response.
        /// </summary>
        public string Data { get; set; }
    }
}
