using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomStringGenerator
{
    /// <summary>
    /// Class for providing API for generating random strings. This class cannot be inherited.
    /// </summary>
    public sealed class Generator
    {
        /// <summary>
        /// Generates a random string using a cryptographically strong Random Number Generator.
        /// </summary>
        /// <param name="characters">Character set that will be used. The number of characters that will be used (After ignoring duplicates or not) should not be less than 2</param>
        /// <param name="length">Required character length of the random string. This should not be less than 1.</param>
        /// <param name="ignoreDuplicates">Whether the duplicates in the character set should be ignored. (Ignored by default)</param>
        /// <returns>A random string based on given parameters.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static string GenerateRandomString(string characters, int length, bool ignoreDuplicates = true)
        {
            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if(string.IsNullOrEmpty(characters))
            {
                throw new ArgumentNullException(nameof(characters));
            }

            if (string.IsNullOrWhiteSpace(characters))
            {
                throw new ArgumentException(nameof(characters));
            }

            int charsetLength = characters.Length;

            if (!ignoreDuplicates)
            {
                if (charsetLength < 2)
                {
                    throw new ArgumentException(nameof(characters));
                }

                using (ServiceProvider provider = new ServiceProvider())
                {
                    return provider.GenerateUsingRNG(characters, charsetLength, length);
                }
            }

            IList<char> uniques = new List<char>
            {
                characters[0]
            };

            foreach (char c in characters)
            {
                if (!uniques.Contains(c))
                {
                    uniques.Add(c);
                }
            }

            charsetLength = uniques.Count;
            if (charsetLength < 2)
            {
                throw new ArgumentException(nameof(characters));
            }

            using (ServiceProvider provider = new ServiceProvider())
            {
                return provider.GenerateUsingRNG(new string(uniques.ToArray()), charsetLength, length);
            }
        }
    }
}