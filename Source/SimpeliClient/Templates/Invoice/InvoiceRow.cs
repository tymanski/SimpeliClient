using Simpeli.Helpers;

namespace Simpeli.Templates
{
    /// <summary>
    /// Model representing row used in Invoice templates.
    /// </summary>
    public class InvoiceRow
    {
        public string rowItemName { get; set; }
        public string rowPrice { get; set; }
        public string rowQuantity { get; set; }
        public string rowTotal { get; set; }

        /// <summary>
        /// Validates template data.
        /// </summary>
        public void Validate()
        {
            ValidationHelper.ValidateStringNotNullNorEmpty(rowItemName, "rowItemName");
            ValidationHelper.ValidateStringNotNullNorEmpty(rowPrice, "rowPrice");
            ValidationHelper.ValidateStringNotNullNorEmpty(rowQuantity, "rowQuantity");
            ValidationHelper.ValidateStringNotNullNorEmpty(rowTotal, "rowTotal");
        }
    }
}
