using Simpeli.Responses;

namespace Simpeli.Interfaces
{
    /// <summary>
    /// Interface for SimpeliClient.
    /// </summary>
    public interface ISimpeliClient
    {
        /// <summary>
        /// Sends request to the API with request to process pdf data defined in <paramref name="template"/>.
        /// </summary>
        /// <param name="template">Object containing data for a template.</param>
        /// <param name="webhook">An URL to which API will send generated pdf file.</param>
        /// <param name="referenceId">A reference Id of the element.</param>
        /// <returns>Response object.</returns>
        SavePdfResponse SavePdf(ITemplate template, string webhook, string referenceId);

        /// <summary>
        /// Returns number of credits available.
        /// </summary>
        /// <returns>Response object.</returns>
        CreditsResponse GetCredits();

        /// <summary>
        /// Registers new payment request in the system. 
        /// </summary>
        /// <param name="creditsAmount">Amount of credits to buy.</param>
        /// <returns>Response object.</returns>
        NewPaymentIdResponse GetNewPaymentId(int creditsAmount);

        /// <summary>
        /// Sending acknowledgement to the system to be charged for a payment identified by <paramref name="paymentId"/>.
        /// </summary>
        /// <param name="paymentId">A payment Id.</param>
        /// <returns>Response object.</returns>
        AddPaymentResponse AddPayment(string paymentId);
    }
}
