using Simpeli.Helpers;

namespace Simpeli.Templates
{
    /// <summary>
    /// A template class for Receipt template.
    /// </summary>
    public class Receipt : TemplateBase
    {
        /// <summary>
        /// The unique Id of the template.
        /// </summary>
        private const string _templateId = "R6A42DZ";

        public string paymentFor { get; set; }
        public string contact { get; set; }
        public string date { get; set; }
        public string accountBilled { get; set; }
        public string item { get; set; }
        public string amount { get; set; }
        public string chargedTo { get; set; }
        public string transactionId { get; set; }
        public string[] images { get; set; }

        /// <summary>
        /// Initialzies new instance of the class.
        /// </summary>
        public Receipt()
        {
            TemplateId = _templateId;
        }

        /// <summary>
        /// Validates template data.
        /// </summary>
        public override void Validate()
        {
            ValidationHelper.ValidateStringNotNullNorEmpty(paymentFor, "paymentFor");
            ValidationHelper.ValidateStringNotNullNorEmpty(contact, "contact");
            ValidationHelper.ValidateStringNotNullNorEmpty(date, "date");
            ValidationHelper.ValidateStringNotNullNorEmpty(accountBilled, "accountBilled");
            ValidationHelper.ValidateStringNotNullNorEmpty(item, "item");
            ValidationHelper.ValidateStringNotNullNorEmpty(amount, "amount");
            ValidationHelper.ValidateStringNotNullNorEmpty(chargedTo, "chargedTo");
            ValidationHelper.ValidateStringNotNullNorEmpty(transactionId, "transactionId");
            ValidationHelper.ValidateStringArray(images, "images");
        }
    }
}
