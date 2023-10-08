using System;
using System.Collections.Generic;

namespace OperationResult.ErrorHandling.Rfc7807
{
    /// <summary>
    ///     Contains arguments necessary for formation of RFC7807 error details object.
    /// </summary>
    public class Rfc7807Args
    {
        /// <summary>
        ///     The URI which describes the occured type of error.
        /// </summary>
        public Uri Type { get; set; }

        /// <summary>
        ///     The URI to see additional details of the occured error for the current request.
        /// </summary>
        public Uri Instance { get; set; }

        /// <summary>
        ///     Errror or Informational messages.
        /// </summary>
        public List<string> Messages { get; set; } 
            = new List<string>();
    }
}
