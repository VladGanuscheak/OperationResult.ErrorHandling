using System;

namespace OperationResult.ErrorHandling.Rfc7807
{
    /// <summary>
    ///     Specifies the link to log trace of the concrete request.
    /// </summary>
    public class Rfc7807EndpointLogAttribute : Attribute
    {
        /// <summary>
        ///     The absolute path to the stack trace of the concrete request
        ///     (may contain generic parameters).
        /// </summary>
        public Uri Instance { get; }

        /// <summary>
        ///     The constructor. Specifies the absolute URI to log trace of the current request.
        /// </summary>
        /// <param name="instance">The path to request's log trace</param>
        public Rfc7807EndpointLogAttribute(string instance)
        {
            Instance = new Uri(instance);
        }
    }
}
