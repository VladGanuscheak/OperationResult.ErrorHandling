using System;

namespace OperationResult.ErrorHandling.Rfc7807
{
    /// <summary>
    ///     Specifies the link to log trace of the concrete request.
    /// </summary>
    /// <remarks>
    ///     The constructor. Specifies the absolute URI to log trace of the current request.
    /// </remarks>
    /// <param name="instance">The path to request's log trace</param>
    [AttributeUsage(AttributeTargets.All)]
    public class Rfc7807EndpointLogAttribute(string instance) : Attribute
    {
        /// <summary>
        ///     The absolute path to the stack trace of the concrete request
        ///     (may contain generic parameters).
        /// </summary>
        public Uri Instance { get; } = new Uri(instance);
    }
}
