using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Simpeli.Constants;
using Simpeli.Responses;

namespace Simpeli
{
    /// <summary>
    /// Base class for REST clients.
    /// </summary>
    public abstract class ClientBase
    {
        #region [FIELDS]
        /// <summary>
        /// HTTP client to perform communication over HTTP protocol.
        /// </summary>
        private HttpClient _client;

        /// <summary>
        /// ApiKey to authenticate in the API.
        /// </summary>
        private string _apiKey;
        #endregion [FIELDS]

        #region [CONSTRUCTOR]
        /// <summary>
        /// Initializes new instance of the class.
        /// </summary>
        /// <param name="apiKey">The Api Key.</param>
        public ClientBase(string apiKey)
        {
            if (String.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("ApiKey cannot be null nor empty", "apiKey");
            }

            _apiKey = apiKey;

            _client = new HttpClient();
        }
        #endregion [CONSTRUCTOR]

        #region [METHODS]
        /// <summary>
        /// Central point of the SimpeliClient. Executes the http request defined in <paramref name="request"/>, which 
        /// is filled with <paramref name="data"/> and set with <paramref name="contentType"/> attribute.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <param name="contentType">Data content type.</param>
        /// <param name="data">Data to be sent.</param>
        /// <returns></returns>
        protected string Execute(HttpRequestMessage request, string contentType, string data = null)
        {
            string result;
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode(_apiKey));

            if (data != null)
            {
                request.Content = new StringContent(data);

                request.Content.Headers.ContentType = new MediaTypeHeaderValue(ContentType.AppJson);
            }

            Task<HttpResponseMessage> task = null;

            try
            {
                task = _client.SendAsync(request);

                if (task.Result.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException();
                }

                result = task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException ex)
            {
                if (task != null)
                {
                    throw new SimpeliException((int) task.Result.StatusCode,
                        task.Result.Content.ReadAsStringAsync().Result, "Simpeli API returned error.", ex);
                }
                else
                {
                    throw new SimpeliException(500, "Internal Server Error.", "Simpeli API returned error.", ex);
                }
            }
            catch (Exception ex)
            {
                throw new SimpeliException(500, "An error occured while calling API. Details: " + ex.Message, "", ex);
            }

            return result;
        }

        /// <summary>
        /// Converts <paramref name="plainText"/> string to Base64,
        /// </summary>
        /// <param name="plainText">String to be encoded.</param>
        /// <returns>Encoded string.</returns>
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        #endregion [METHODS]
    }
}
