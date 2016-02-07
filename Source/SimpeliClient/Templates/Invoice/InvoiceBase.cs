using Simpeli.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli.Templates
{
    public abstract class InvoiceBase : TemplateBase
    {   
        public string invoiceNr { get; set; }
        public string date { get; set; }
        public string dueDate { get; set; }
        public string fromCompanyName { get; set; }
        public string fromAddress { get; set; }
        public string fromCity { get; set; }
        public string fromState { get; set; }
        public string fromCountry { get; set; }
        public string fromPostal { get; set; }
        public string fromContact { get; set; }
        public string toCompanyName { get; set; }
        public string toAddress { get; set; }
        public string toCity { get; set; }
        public string toState { get; set; }
        public string toCountry { get; set; }
        public string toPostal { get; set; }
        public string toContact { get; set; }
        public string comments { get; set; }
        public string subtotal { get; set; }
        public string taxRate { get; set; }
        public string taxDue { get; set; }
        public string other { get; set; }
        public string total { get; set; }
        public string taxable { get; set; }
        public string[] images { get; set; }
        public InvoiceRow[] rows { get; set; }

        /// <summary>
        /// Validates template data.
        /// </summary>
        public override void Validate()
        {
            ValidationHelper.ValidateStringNotNullNorEmpty(invoiceNr, "invoiceNr");
            ValidationHelper.ValidateStringNotNullNorEmpty(date, "date");
            ValidationHelper.ValidateStringNotNullNorEmpty(dueDate, "dueDate");
            ValidationHelper.ValidateStringNotNullNorEmpty(fromCompanyName, "fromCompanyName");
            ValidationHelper.ValidateStringNotNullNorEmpty(fromAddress, "fromAddress");
            ValidationHelper.ValidateStringNotNullNorEmpty(fromCity, "fromCity");
            ValidationHelper.ValidateStringNotNullNorEmpty(fromState, "fromState");
            ValidationHelper.ValidateStringNotNullNorEmpty(fromCountry, "fromCountry");
            ValidationHelper.ValidateStringNotNullNorEmpty(fromPostal, "fromPostal");
            ValidationHelper.ValidateStringNotNullNorEmpty(fromContact, "fromContact");
            ValidationHelper.ValidateStringNotNullNorEmpty(toCompanyName, "toCompanyName");
            ValidationHelper.ValidateStringNotNullNorEmpty(toAddress, "toAddress");
            ValidationHelper.ValidateStringNotNullNorEmpty(toCity, "toCity");
            ValidationHelper.ValidateStringNotNullNorEmpty(toState, "toState");
            ValidationHelper.ValidateStringNotNullNorEmpty(toCountry, "toCountry");
            ValidationHelper.ValidateStringNotNullNorEmpty(toPostal, "toPostal");
            ValidationHelper.ValidateStringNotNullNorEmpty(toContact, "toContact");
            ValidationHelper.ValidateStringNotNullNorEmpty(comments, "comments");
            ValidationHelper.ValidateStringNotNullNorEmpty(subtotal, "subtotal");
            ValidationHelper.ValidateStringNotNullNorEmpty(taxRate, "taxRate");
            ValidationHelper.ValidateStringNotNullNorEmpty(taxDue, "taxDue");
            ValidationHelper.ValidateStringNotNullNorEmpty(other, "other");
            ValidationHelper.ValidateStringNotNullNorEmpty(total, "total");
            ValidationHelper.ValidateStringNotNullNorEmpty(taxable, "taxable");

            ValidationHelper.ValidateStringArray(images, "images");

            ValidateRows(rows);
        }

        /// <summary>
        /// Validates template data.
        /// </summary>
        private void ValidateRows(InvoiceRow[] rows)
        {
            if (rows != null && !rows.Any())
            {
                throw new ArgumentException("Value cannot be null nor empty.", "rows");
            }
        }
    }
}
