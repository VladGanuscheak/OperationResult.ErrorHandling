using System;

namespace OperationResult.ErrorHandling.Rfc7807
{
    /// <summary>
    ///     Ignores the method it is applied above to be handled by the Rfc7807 attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class IgnoreRfc7807Attribute : Attribute
    {
    }
}
