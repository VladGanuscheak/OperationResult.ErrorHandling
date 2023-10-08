using System.Collections.Generic;
using System.Net;

namespace OperationResult.ErrorHandling.Rfc9110
{
    /// <summary>
    ///     Defines default documentation for each Http Status code
    ///     (see the RFC 9110 for reference).
    /// </summary>
    public static class Rfc9110
    {
        private const int AnusedErrorCode = 418;
        private const int MisdirectedErrorCode = 421;
        private const int UnprocessableContentErrorCode = 422;

        /// <summary>
        ///     The Dictionary which maps Client Http Errors (400-499) with corresponding documentation from RFC 9110. 
        /// </summary>
        public static Dictionary<int, string> ClientErrorCodes = new Dictionary<int, string>
        {
            { (int)HttpStatusCode.BadRequest, "https://www.rfc-editor.org/rfc/rfc9110.html#name-400-bad-request" },
            { (int)HttpStatusCode.Unauthorized, "https://www.rfc-editor.org/rfc/rfc9110.html#name-401-unauthorized" },
            { (int)HttpStatusCode.PaymentRequired, "https://www.rfc-editor.org/rfc/rfc9110.html#name-402-payment-required" },
            { (int)HttpStatusCode.Forbidden, "https://www.rfc-editor.org/rfc/rfc9110.html#name-403-forbidden" },
            { (int)HttpStatusCode.NotFound, "https://www.rfc-editor.org/rfc/rfc9110.html#name-404-not-found" },
            { (int)HttpStatusCode.MethodNotAllowed, "https://www.rfc-editor.org/rfc/rfc9110.html#name-405-method-not-allowed" },
            { (int)HttpStatusCode.NotAcceptable, "https://www.rfc-editor.org/rfc/rfc9110.html#name-406-not-acceptable" },
            { (int)HttpStatusCode.ProxyAuthenticationRequired, "https://www.rfc-editor.org/rfc/rfc9110.html#name-407-proxy-authentication-re" },
            { (int)HttpStatusCode.RequestTimeout, "https://www.rfc-editor.org/rfc/rfc9110.html#name-408-request-timeout" },
            { (int)HttpStatusCode.Conflict, "https://www.rfc-editor.org/rfc/rfc9110.html#name-409-conflict" },
            { (int)HttpStatusCode.Gone, "https://www.rfc-editor.org/rfc/rfc9110.html#name-410-gone" },
            { (int)HttpStatusCode.LengthRequired, "https://www.rfc-editor.org/rfc/rfc9110.html#name-411-length-required" },
            { (int)HttpStatusCode.PreconditionFailed, "https://www.rfc-editor.org/rfc/rfc9110.html#name-412-precondition-failed" },
            { (int)HttpStatusCode.RequestEntityTooLarge, "https://www.rfc-editor.org/rfc/rfc9110.html#name-413-content-too-large" },
            { (int)HttpStatusCode.RequestUriTooLong, "https://www.rfc-editor.org/rfc/rfc9110.html#name-414-uri-too-long" },
            { (int)HttpStatusCode.UnsupportedMediaType, "https://www.rfc-editor.org/rfc/rfc9110.html#name-415-unsupported-media-type" },
            { (int)HttpStatusCode.RequestedRangeNotSatisfiable, "https://www.rfc-editor.org/rfc/rfc9110.html#name-416-range-not-satisfiable" },
            { (int)HttpStatusCode.ExpectationFailed, "https://www.rfc-editor.org/rfc/rfc9110.html#name-417-expectation-failed" },
            { AnusedErrorCode, "https://www.rfc-editor.org/rfc/rfc9110.html#name-418-unused" },
            { MisdirectedErrorCode, "https://www.rfc-editor.org/rfc/rfc9110.html#name-421-misdirected-request" },
            { UnprocessableContentErrorCode, "https://www.rfc-editor.org/rfc/rfc9110.html#name-422-unprocessable-content" },
            { (int)HttpStatusCode.UpgradeRequired, "https://www.rfc-editor.org/rfc/rfc9110.html#name-426-upgrade-required" }
        };
    }
}
