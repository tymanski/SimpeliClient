using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli.Templates
{
    /// <summary>
    /// A template class for Invoice template.
    /// </summary>
    public class InvoiceA : InvoiceBase
    {
        /// <summary>
        /// The unique Id of the template.
        /// </summary>
        private const string _templateId = "I8SGRHT";

        /// <summary>
        /// Initialzies new instance of the class.
        /// </summary>
        public InvoiceA()
        {
            TemplateId = _templateId;
        }
    }
}
