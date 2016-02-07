using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli
{
    /// <summary>
    /// A client to communicate with Simpe.li REST API.
    /// </summary>
    public class SimpeliClient : ClientBase, ISimpeliClient
    {
        private string _apiUrl;

        #region [CONSTRUCTOR]
        /// <summary>
        /// Initializes new instance of SimpeliClient.
        /// </summary>
        /// <param name="apiKey">An apiKey used to authenticate in the API.</param>
        public SimpeliClient(string apiKey, string apiUrl) : base(apiKey)
        {
            _apiUrl = apiUrl;
        }
        #endregion [CONSTRUCTOR]

        #region [PUBLIC METHODS]
        /// <summary>
        /// Sending acknowledgement to the system to be charged for a payment identified by <paramref name="paymentId"/>.
        /// </summary>
        /// <param name="paymentId">A payment Id.</param>
        /// <returns></returns>
        public AddPaymentResponse AddPayment(string paymentId)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_apiUrl + "payments/" + paymentId),
                Method = HttpMethod.Post,
            };

            string jsonResult = base.Execute(request, ContentType.APP_JSON);

            return JsonConvert.DeserializeObject<AddPaymentResponse>(jsonResult);
        }

        /// <summary>
        /// Returns number of credits available.
        /// </summary>
        /// <returns></returns>
        public CreditsResponse GetCredits()
        {
            //throw new NotImplementedException();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_apiUrl + "credits"),
                Method = HttpMethod.Get,
            };

            string jsonResult = base.Execute(request, ContentType.APP_JSON);

            return JsonConvert.DeserializeObject<CreditsResponse>(jsonResult);
        }

        /// <summary>
        /// Registers new payment request in the system. 
        /// </summary>
        /// <param name="creditsAmount">Amount of credits to buy.</param>
        /// <returns></returns>
        public NewPaymentIdResponse GetNewPaymentId(int creditsAmount)
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_apiUrl + "payments/new?credits=" + creditsAmount.ToString()),
                Method = HttpMethod.Get,
            };
           
            string jsonResult = base.Execute(request, ContentType.APP_JSON);

            return JsonConvert.DeserializeObject<NewPaymentIdResponse>(jsonResult);
        }

        /// <summary>
        /// Sends request to the API with request to process pdf data defined in <paramref name="template"/>.
        /// </summary>
        /// <param name="template">Object containing data for a template.</param>
        /// <param name="webhook">An URL to which API will send generated pdf file.</param>
        /// <param name="referenceId">A reference Id of the element.</param>
        /// <returns></returns>
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

            string jsonResult = base.Execute(request, ContentType.APP_JSON, data);
            return JsonConvert.DeserializeObject<SavePdfResponse>(jsonResult);
        }
        #endregion [PUBLIC METHODS]
    }
}
