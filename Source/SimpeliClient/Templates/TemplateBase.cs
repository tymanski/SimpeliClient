using Newtonsoft.Json;
using Simpeli.Interfaces;

namespace Simpeli.Templates
{
    /// <summary>
    /// An abstract class for templates.
    /// </summary>
    public abstract class TemplateBase : ITemplate
    {
        /// <summary>
        /// The unique Id of the template.
        /// </summary>
        protected string TemplateId;

        /// <summary>
        /// Returns Id of the template.
        /// </summary>
        /// <returns>Template Id.</returns>
        public string GetTemplateId()
        {
            return TemplateId;
        }

        /// <summary>
        /// Returns JSON strinf representation of an object.
        /// </summary>
        /// <returns>String in JSON format.</returns>
        public string ToJson()
        {
            string result = JsonConvert.SerializeObject(this);

            return result;
        }

        /// <summary>
        /// Validates template data.
        /// </summary>
        public abstract void Validate();
    }
}
