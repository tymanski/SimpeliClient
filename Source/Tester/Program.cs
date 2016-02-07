using Simpeli;
using Simpeli.Templates;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        #region [FIELDS]
        // Your API key:
        private const string API_KEY = "ENTER_YOUR_APIKEY_HERE";

        // A WebHook - url which will be called after PDF is generated.
        // Check Simpeli documentation for more info.
        private const string WEB_HOOK = "webhookurl";

        // A root url to the API
        private const string API_URL = "https://api.simpe.li/v1/";
        #endregion

        /// <summary>
        /// Demonstration of using SimpeliClient. Execution of all available methods.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Initialize SimpeliClient instance
            SimpeliClient client = new SimpeliClient(API_KEY, API_URL);

            //
            // Send data for PDF generation
            //
            Console.WriteLine("Sending data for template: Receipt...");
            SendReceipt(client);

            Console.WriteLine(Environment.NewLine + "Sending data for template: Invoice (1)...");
            SendInvoiceA(client);

            Console.WriteLine(Environment.NewLine + "Sending data for template: Invoice (2)...");
            SendInvoiceB(client);

            Console.WriteLine(Environment.NewLine + "Sending data for template: Invoice (3)...");
            SendInvoiceC(client);

            Console.WriteLine(Environment.NewLine + "Sending data for template: Invoice (4)...");
            SendInvoiceD(client);

            Console.WriteLine(Environment.NewLine + "Sending data for template: Cards...");
            SendCards(client);

            //
            // Other methods
            //

            Console.WriteLine(Environment.NewLine + "Retrieving current credit balance...");
            GetCredits(client);

            Console.WriteLine(Environment.NewLine + "Initializing new payment session, retrieving PaymentId...");
            NewPaymentIdResponse response = GetNewPayment(client);

            if (response != null)
            {
                Console.WriteLine(Environment.NewLine + "Confirming new payment...");
                AddPayment(client, response.paymentId);
            }

            Console.WriteLine(Environment.NewLine + "Retrieving current credit balance...");
            GetCredits(client);


            // Wait..
            Console.ReadLine();
        }

        #region [EXECUTING METHODS]
        /// <summary>
        /// Will execute generating pdf with Receipt template.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static void SendReceipt(SimpeliClient client)
        {
            try
            {
                SavePdfResponse response = null;

                Receipt receipt = new Receipt();
                receipt.accountBilled = "1233-554-525";
                receipt.amount = "120";
                receipt.chargedTo = "John S.";
                receipt.contact = "Johnny@pl.ok";
                receipt.date = DateTime.Now.ToString();
                receipt.images = new string[] { "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==" };
                receipt.item = "Pink Bicycle";
                receipt.paymentFor = "-";
                receipt.transactionId = "22/56";

                response = client.SavePdf(receipt, WEB_HOOK, "my_ref_number"); 

                Console.WriteLine("Result of sending: " + response.message);
            }
            catch (SimpeliException ex)
            {
                HandleSimpeliException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Will execute generating pdf with Invoice template.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static void SendInvoiceA(SimpeliClient client)
        {
            try
            {
                SavePdfResponse response = null;

                InvoiceA invoice = new InvoiceA();

                FillInvoceData(invoice);

                response = client.SavePdf(invoice, WEB_HOOK, "my_ref_number");

                Console.WriteLine("Result of sending: " + response.message);
            }
            catch (SimpeliException ex)
            {
                HandleSimpeliException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Will execute generating pdf with Invoice template.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static void SendInvoiceB(SimpeliClient client)
        {
            try
            {
                SavePdfResponse response = null;

                InvoiceB invoice = new InvoiceB();

                FillInvoceData(invoice);

                response = client.SavePdf(invoice, WEB_HOOK, "my_ref_number");

                Console.WriteLine("Result of sending: " + response.message);
            }
            catch (SimpeliException ex)
            {
                HandleSimpeliException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Will execute generating pdf with Invoice template.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static void SendInvoiceC(SimpeliClient client)
        {
            try
            {
                SavePdfResponse response = null;

                InvoiceC invoice = new InvoiceC();

                FillInvoceData(invoice);

                response = client.SavePdf(invoice, WEB_HOOK, "my_ref_number"); 

                Console.WriteLine("Result of sending: " + response.message);
            }
            catch (SimpeliException ex)
            {
                HandleSimpeliException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Will execute generating pdf with Invoice template.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static void SendInvoiceD(SimpeliClient client)
        {
            try
            {
                SavePdfResponse response = null;

                InvoiceD invoice = new InvoiceD();

                FillInvoceData(invoice);

                response = client.SavePdf(invoice, WEB_HOOK, "my_ref_number"); 

                Console.WriteLine("Result of sending: " + response.message);
            }
            catch (SimpeliException ex)
            {
                HandleSimpeliException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Will execute generating pdf with Cards template.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static void SendCards(SimpeliClient client)
        {
            try
            {
                SavePdfResponse response = null;

                Cards cards = new Cards();
                cards.images = new string[]
                {
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==",
                    "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg=="
                };
                cards.text0 = "testA";
                cards.text1 = "testB";
                cards.text2 = "testC";
                cards.text3 = "testD";
                cards.text4 = "testE";
                cards.text5 = "testF";
                cards.text6 = "testG";
                cards.text7 = "testH";
                cards.text8 = "testI";
                cards.text9 = "testJ";



                response = client.SavePdf(cards, WEB_HOOK, "my_ref_number");

                Console.WriteLine("Result of sending: " + response.message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Returns available credits.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static void GetCredits(SimpeliClient client)
        {
            try
            {
                CreditsResponse response = client.GetCredits();

                Console.WriteLine("Credits: "+response.amount.ToString());
            }
            catch (SimpeliException ex)
            {
                HandleSimpeliException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Will initialize new payment.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static NewPaymentIdResponse GetNewPayment(SimpeliClient client)
        {
            NewPaymentIdResponse response = null;

            try
            {
                response = client.GetNewPaymentId(150);

                Console.WriteLine("Response (New Payment): " + Environment.NewLine +
                    "paymentId = " + response.paymentId + Environment.NewLine +
                    "price = "+ response.price + Environment.NewLine +
                    "message = " + response.message);
            }
            catch (SimpeliException ex)
            {
                HandleSimpeliException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return response;
        }

        /// <summary>
        /// Will accomplish payment from last step.
        /// </summary>
        /// <param name="client">SimpeliClient instance.</param>
        private static void AddPayment(SimpeliClient client, string paymentId)
        {
            try
            {
                AddPaymentResponse response = null;

                response = client.AddPayment(paymentId);

                Console.WriteLine("Result of payment: " + response.message);
            }
            catch (SimpeliException ex)
            {
                HandleSimpeliException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region [OTHERS]
        /// <summary>
        /// Handles all errors or exceptions returned from Simpeli API. 
        /// </summary>
        /// <param name="ex">Exception object containing details of error returned by Simpeli API.</param>
        private static void HandleSimpeliException(SimpeliException ex)
        {
            Console.WriteLine(ex.Error.StatusCode.ToString() + ":" + ex.Error.Data);
        }

        /// <summary>
        /// Handles all errors and exceptions that are not related to Simpeli API.
        /// </summary>
        /// <param name="ex">Exception object.</param>
        private static void HandleException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        /// <summary>
        /// Helper method used to fill data for invoice templates.
        /// </summary>
        /// <param name="invoice"></param>
        private static void FillInvoceData(InvoiceBase invoice)
        {
            invoice.invoiceNr = "12345";
            invoice.date = DateTime.UtcNow.ToString();
            invoice.dueDate = "-";
            invoice.fromCompanyName = "ACME";
            invoice.fromAddress = "Yellow St, 69/a";
            invoice.fromCity = "New York";
            invoice.fromState = "-";
            invoice.fromCountry = "USA";
            invoice.fromPostal = "11-665";
            invoice.fromContact = "John B.";
            invoice.toCompanyName = "Coctails SA.";
            invoice.toAddress = "Red Blvrd 9";
            invoice.toCity = "Tbilisi";
            invoice.toState = "-";
            invoice.toCountry = "Georgia";
            invoice.toPostal = "99";
            invoice.toContact = "Mungashvili.";
            invoice.comments = "-";
            invoice.subtotal = "100";
            invoice.taxRate = "0";
            invoice.taxDue = "-";
            invoice.other = "-";
            invoice.total = "100";
            invoice.taxable = "0";

            invoice.rows = new InvoiceRow[] {
                new InvoiceRow { rowItemName = "Element", rowPrice = "20", rowQuantity = "2", rowTotal = "40" },
                new InvoiceRow { rowItemName = "Something", rowPrice = "15", rowQuantity = "4", rowTotal = "60" },
            };

            invoice.images = new string[] { "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAAAAAA6fptVAAAACklEQVR4nGNiAAAABgADNjd8qAAAAABJRU5ErkJggg==" };
        }
        #endregion
    }
}
