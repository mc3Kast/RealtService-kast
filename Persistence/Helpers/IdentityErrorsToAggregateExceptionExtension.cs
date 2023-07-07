using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.Helpers;

public static class IdentityErrorsToAggregateExceptionExtension
{
    public static AggregateException AsAggregateException(this IEnumerable<IdentityError> errors, string? message = null)
    {
        ICollection<Exception> exceptions = new List<Exception>();
        foreach (IdentityError error in errors)
        {
            exceptions.Add(new Exception(message: $"Identity error #{error.Code} raised: {error.Description}"));
        }

        return (message is null) ? new AggregateException(innerExceptions: exceptions) : new AggregateException(message: message, innerExceptions: exceptions); 
    }
}
