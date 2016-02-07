using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simpeli
{
    /// <summary>
    /// A base class for SimpeliClient.
    /// </summary>
    public abstract class ClientBase
    {
        #region [FIELDS]
        /// <summary>
        /// A HTTP client to perform comunication over HTTP protocol.
        /// </summary>
        private HttpClient _client;

        /// <summary>
        /// ApiKey to authenticate in the API.
        /// </summary>
        private string _apiKey;
        #endregion [FIELDS]

        #region [CONSTRUCTOR]
        /// <summary>
        /// Initailzes new instance of the class.
        /// </summary>
        /// <param name="apiKey">An apiKey.</param>
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
        /// Central point of SimpeliClient. It executes an http reqquest defined in <paramref name="request"/>, which 
        /// is fileld with <paramref name="data"/> and set with <paramref name="contentType"/> attribute.
        /// </summary>
        /// <param name="request">A request object.</param>
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

                request.Content.Headers.ContentType = new MediaTypeHeaderValue(ContentType.APP_JSON);
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
                throw new SimpeliException((int)task.Result.StatusCode, task.Result.Content.ReadAsStringAsync().Result, "Simpeli API returned error.", ex);
            }
            catch (Exception ex)
            {
                throw new SimpeliException(500, "An error occured while calling API. Details: " + ex.Message, "", ex);
            }

            return result;
        }

        /// <summary>
        /// Converts string to Base64,
        /// </summary>
        /// <param name="plainText">A string to be encoded.</param>
        /// <returns>Encoded string.</returns>
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        #endregion [METHODS]
    }
}
