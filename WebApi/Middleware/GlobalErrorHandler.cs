using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;

namespace RealtService.WebApi.Middleware;

public class GlobalErrorHandler: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case ValidationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            string result = $"Message: {error.Message},\r\n Source: {error.Source},\r\n StackTrace: {error.StackTrace}";
            await response.WriteAsync(result);
        }
    }
}
