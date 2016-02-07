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
    public class InvoiceB : InvoiceBase
    {
        /// <summary>
        /// The unique Id of the template.
        /// </summary>
        private const string _templateId = "I5HPG2R";

        /// <summary>
        /// Initialzies new instance of the class.
        /// </summary>
        public InvoiceB()
        {
            TemplateId = _templateId;
        }
    }
}
