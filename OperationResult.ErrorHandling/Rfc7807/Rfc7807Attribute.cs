using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Reflection;
using RfcProtocol9110 = OperationResult.ErrorHandling.Rfc9110;

namespace OperationResult.ErrorHandling.Rfc7807
{
    public class Rfc7807Attribute : ActionFilterAttribute
    {
        /// <summary>
        ///     Defines the base overridable functionality in order to return Error Details object.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="args"></param>
        protected virtual void AttachRfc7807Result(
            ref ObjectResult response,
            Rfc7807Args args)
        {
            dynamic problemDetails = new ExpandoObject();

            var content = args.Messages.Any() ? string.Join("; ", args.Messages) : null;

            problemDetails.Title = "Failure Result";
            problemDetails.Status = response.StatusCode;
            problemDetails.Detail = content;

            if (args.Type == null)
            {
                if (RfcProtocol9110.Rfc9110.ClientErrorCodes.ContainsKey((int)response.StatusCode))
                {
                    args.Type = new Uri(RfcProtocol9110.Rfc9110.ClientErrorCodes[(int)response.StatusCode]);
                }
            }

            if (args.Type != null)
            {
                problemDetails.Type = args.Type;
            }

            if (args.Instance != null)
            {
                problemDetails.Instance = args.Instance;
            }

            response.Value = problemDetails;
        }

        /// <summary>
        ///     Handles the OperationResult's cast from ActionResult with array of strings into the ActionResult with ErrorDetails 
        ///     (if the result of the mentioned operation is a client error code).
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="Exception"></exception>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ActionDescriptor.RouteValues.TryGetValue("action", out var actionName))
            {
                throw new Exception("The action has not been found!");
            }

            MethodInfo methodInfo = context.Controller.GetType().GetMethod(actionName);

            var hasIgnoreAttribute = methodInfo.GetCustomAttributes(typeof(IgnoreRfc7807Attribute), true).Any();

            if (!hasIgnoreAttribute)
            {
                var result = context.Result as ObjectResult;

                if (result != null)
                {
                    if (result.StatusCode >= (int)HttpStatusCode.BadRequest &&
                        result.StatusCode < (int)HttpStatusCode.InternalServerError)
                    {
                        if (context.Result is ObjectResult objectResult)
                        {
                            if (objectResult.Value != null)
                            {
                                if (objectResult.Value is List<string> messages)
                                {
                                    var type = methodInfo.GetCustomAttributes<Rfc7807EndpointAttribute>()
                                            .FirstOrDefault(x => (int)x.StatusCode == objectResult.StatusCode)
                                            ?.Type;

                                    var instance = methodInfo.GetCustomAttribute<Rfc7807EndpointLogAttribute>()
                                        ?.Instance;

                                    AttachRfc7807Result(ref objectResult, new Rfc7807Args
                                    {
                                        Type = type,
                                        Instance = instance,
                                        Messages = messages
                                    });
                                }
                            }
                        }
                    }
                }
            }

            base.OnResultExecuting(context);
        }
    }
}
