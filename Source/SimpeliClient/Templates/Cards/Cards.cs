using Simpeli.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli.Templates
{
    /// <summary>
    /// A template class for Cards template.
    /// </summary>
    public class Cards : TemplateBase
    {
        /// <summary>
        /// The unique Id of the template.
        /// </summary>
        private const string _templateId = "C8EAUBP";

        public string text0 { get; set; }
        public string text1 { get; set; }
        public string text2 { get; set; }
        public string text3 { get; set; }
        public string text4 { get; set; }
        public string text5 { get; set; }
        public string text6 { get; set; }
        public string text7 { get; set; }
        public string text8 { get; set; }
        public string text9 { get; set; }

        public string[] images { get; set; }

        /// <summary>
        /// Initialzies new instance of the class.
        /// </summary>
        public Cards()
        {
            TemplateId = _templateId;
        }

        /// <summary>
        /// Validates template data.
        /// </summary>
        public override void Validate()
        {
            //ValidationHelper.ValidateStringArray(strings, "strings");
            ValidationHelper.ValidateStringArray(images, "images");
        }
    }
}
