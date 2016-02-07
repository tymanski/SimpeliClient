using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli
{
    /// <summary>
    /// Interface for all templates.
    /// </summary>
    public interface ITemplate
    {
        /// <summary>
        /// Returns JSON strinf representation of an object.
        /// </summary>
        /// <returns>String in JSON format.</returns>
        string ToJson();

        /// <summary>
        /// Returns Id of the template.
        /// </summary>
        /// <returns>Template Id.</returns>
        string GetTemplateId();

        /// <summary>
        /// Validates template data.
        /// </summary>
        void Validate();
    }
}
