using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli.Templates
{
    public class InvoiceE : InvoiceBase
    {
        private const string _templateId = "6A42DZ";

        public InvoiceE()
        {
            TemplateId = _templateId;
        }
    }
}
