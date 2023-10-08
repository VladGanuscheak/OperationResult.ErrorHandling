using System;
using System.Net;

namespace OperationResult.ErrorHandling.Rfc7807
{
    /// <summary>
    ///     Defines custom link to the specified Http status error code 
    ///     (applied to Type property of Problem Details object of RFC7807).
    /// </summary>
    public class Rfc7807EndpointAttribute : Attribute
    {
        /// <summary>
        ///     Client Error status code
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        ///     The URI which describes the error with the specified HTTP status code.
        /// </summary>
        public Uri Type { get; }

        /// <summary>
        ///     The Constructor. Specifies the custom link for the occured error type.
        /// </summary>
        /// <param name="statusCode">Required. Status code.</param>
        /// <param name="type">The uri to the documentation for the specified Http status code.</param>
        public Rfc7807EndpointAttribute(HttpStatusCode statusCode, string type)
        {
            StatusCode = statusCode;
            Type = new Uri(type);
        }
    }
}
