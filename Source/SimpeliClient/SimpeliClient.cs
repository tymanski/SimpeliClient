using Newtonsoft.Json;
using System;
using System.Net.Http;
using Simpeli.Constants;
using Simpeli.Interfaces;
using Simpeli.Responses;

namespace Simpeli
{
    /// <summary>
    /// Client to communicate with Simpe.li REST API.
    /// </summary>
    public class SimpeliClient : ClientBase, ISimpeliClient
    {
        /// <summary>
        /// The _api URL
        /// </summary>
        private string _apiUrl;

        #region [CONSTRUCTOR]

        /// <summary>
        /// Initializes new instance of SimpeliClient.
        /// </summary>
        /// <param name="apiKey">The apiKey used to authenticate in the API.</param>
        /// <param name="apiUrl">The API URL.</param>
        public SimpeliClient(string apiKey, string apiUrl) : base(apiKey)
        {
            _apiUrl = apiUrl;
        }
        #endregion [CONSTRUCTOR]

        #region [PUBLIC METHODS]
        /// <summary>
        /// Sending acknowledgment to the system to be charged for a payment identified by <paramref name="paymentId"/>.
        /// </summary>
        /// <param name="paymentId">A payment Id.</param>
        /// <returns>Response message from API.</returns>
        public AddPaymentResponse AddPayment(string paymentId)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_apiUrl + "payments/" + paymentId),
                Method = HttpMethod.Post,
            };

            string jsonResult = Execute(request, ContentType.AppJson);

            return JsonConvert.DeserializeObject<AddPaymentResponse>(jsonResult);
        }

        /// <summary>
        /// Returns number of credits available.
        /// </summary>
        /// <returns>Response message from API containing available credits.</returns>
        public CreditsResponse GetCredits()
        {
            //throw new NotImplementedException();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_apiUrl + "credits"),
                Method = HttpMethod.Get,
            };

            string jsonResult = Execute(request, ContentType.AppJson);

            return JsonConvert.DeserializeObject<CreditsResponse>(jsonResult);
        }

        /// <summary>
        /// Registers new payment request in the system. 
        /// </summary>
        /// <param name="creditsAmount">Amount of credits to buy.</param>
        /// <returns>Response message from API containing paymentId.</returns>
        public NewPaymentIdResponse GetNewPaymentId(int creditsAmount)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_apiUrl + "payments/new?credits=" + creditsAmount.ToString()),
                Method = HttpMethod.Get,
            };
           
            string jsonResult = Execute(request, ContentType.AppJson);

            return JsonConvert.DeserializeObject<NewPaymentIdResponse>(jsonResult);
        }

        /// <summary>
        /// Sends request to the API with request to process pdf data defined in <paramref name="template"/>.
        /// </summary>
        /// <param name="template">Object containing data for a template.</param>
        /// <param name="webhook">An URL to which API will send generated pdf file.</param>
        /// <param name="referenceId">A reference Id of the element.</param>
        /// <returns>Response message from API.</returns>
        public SavePdfResponse SavePdf(ITemplate template, string webhook, string referenceId)
        {
            // Validate template
            template.Validate();

            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_apiUrl + "pdfs"),
                Method = HttpMethod.Post
            };

            request.Headers.Add("webhook", webhook);
            request.Headers.Add("referenceId", referenceId);
            request.Headers.Add("templateId", template.GetTemplateId());

            string data = JsonConvert.SerializeObject(template);

            string jsonResult = Execute(request, ContentType.AppJson, data);
            return JsonConvert.DeserializeObject<SavePdfResponse>(jsonResult);
        }
        #endregion [PUBLIC METHODS]
    }
}
