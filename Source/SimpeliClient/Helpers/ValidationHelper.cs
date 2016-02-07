using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpeli.Helpers
{
    /// <summary>
    /// Validation methods.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Checks if a string is not null and is not empty.
        /// </summary>
        /// <param name="element">A string element to be checked.</param>
        /// <param name="name">Name of the element.</param>
        /// <exception cref="System.ArgumentException">Thrown if element is null or empty.</exception>
        public static void ValidateStringNotNullNorEmpty(string element, string name)
        {
            if (String.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Value cannot be null nor empty.", name);
            }
        }

        /// <summary>
        /// Checks if an array is not null and if each element of this array is not null and is not empty.
        /// </summary>
        /// <param name="element">A string array to be checked.</param>
        /// <param name="name">Name of the element.</param>
        /// <exception cref="System.ArgumentException">Thrown if array is null or if any element is null or empty</exception>
        public static void ValidateStringArray(string[] array, string name)
        {
            if (array == null)
            {
                throw new ArgumentException("Array cannot be empty.", name);
            }

            foreach (string element in array)
            {
                if (String.IsNullOrEmpty(element))
                {
                    throw new ArgumentException("Value of the array cannot be null nor empty.", name + "[]");
                }
            }

        }
    }
}
