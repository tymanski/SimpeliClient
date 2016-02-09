namespace Simpeli.Responses
{
    /// <summary>
    /// Response from NewPaymentId call.
    /// </summary>
    public class NewPaymentIdResponse
    {
        public string paymentId { get; set; }

        public string price { get; set; }

        public string message { get; set; }
    }
}
