using System;
using System.Net;

namespace OperationResult.ErrorHandling.Rfc7807
{
    /// <summary>
    ///     Defines custom link to the specified Http status error code 
    ///     (applied to Type property of Problem Details object of RFC7807).
    /// </summary>
    /// <remarks>
    ///     The Constructor. Specifies the custom link for the occured error type.
    /// </remarks>
    /// <param name="statusCode">Required. Status code.</param>
    /// <param name="type">The uri to the documentation for the specified Http status code.</param>
    [AttributeUsage(AttributeTargets.All)]
    public class Rfc7807EndpointAttribute(HttpStatusCode statusCode, string type) : Attribute
    {
        /// <summary>
        ///     Client Error status code
        /// </summary>
        public HttpStatusCode StatusCode { get; } = statusCode;

        /// <summary>
        ///     The URI which describes the error with the specified HTTP status code.
        /// </summary>
        public Uri Type { get; } = new Uri(type);
    }
}
