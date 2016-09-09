using System;
using System.Linq;
using Nancy;
using designPatterns.Domain;
using designPatterns.Domain.Exceptions;

namespace designPatterns.Web.Api.Infrastructure.RestExceptions
{
    public class CommandValidationExceptionRepackager : IExceptionRepackager
    {
        public ErrorResponse Repackage(Exception exception, NancyContext context, string contentType)
        {
            var failures =
                ((CommandValidationException) exception).ValidationFailures.Select(
                    x => string.Format("{0} ({1})", x.Property, x.FailureType));
            var message = string.Format("{0}: {1}", exception.Message, string.Join(", ", failures));
            return new ErrorResponse(message, HttpStatusCode.BadRequest, contentType);
        }

        public bool CanHandle(Exception exception, string contentType)
        {
            return exception is CommandValidationException;
        }
    }
}