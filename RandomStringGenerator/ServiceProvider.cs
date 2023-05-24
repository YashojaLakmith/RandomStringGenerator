using System;
using System.Security.Cryptography;

namespace RandomStringGenerator
{
    /// <summary>
    /// Class for providing access for Cryptographic services. This class cannot be inherited.
    /// </summary>
    internal sealed class ServiceProvider : IDisposable
    {
        private char[]? buffer;
        private bool disposed;

        /// <summary>
        /// Generates a random string based on given parameters using .NET cryptographic library's Random Number Generator.
        /// </summary>
        /// <param name="characters">Character set to be used.</param>
        /// <param name="charArrayLength">Size of the character set.</param>
        /// <param name="length">Required length of the random string.</param>
        /// <returns>A random string based on given parameters.</returns>
        /// <exception cref="ObjectDisposedException"></exception>
        internal string GenerateUsingRNG(string characters, int charArrayLength, int length)
        {
            if (disposed)
            {
                throw new ObjectDisposedException($"The object {GetType().FullName} has been disposed.");
            }

            buffer = new char[length];

            for (int i = 0; i < length; i++)
            {
                buffer[i] = characters[RandomNumberGenerator.GetInt32(charArrayLength)];
            }

            return new string(buffer);
        }

        /// <summary>
        /// Disposes of all resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Explicitely nullifies used variables.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if(!disposed)
            {
                buffer = null;
                disposed = true;
            }
        }
    }
}
