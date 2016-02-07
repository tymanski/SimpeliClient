using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli
{
    /// <summary>
    /// A response from NewPaymentId call.
    /// </summary>
    public class NewPaymentIdResponse
    {
        public string paymentId { get; set; }

        public string price { get; set; }

        public string message { get; set; }
    }
}
