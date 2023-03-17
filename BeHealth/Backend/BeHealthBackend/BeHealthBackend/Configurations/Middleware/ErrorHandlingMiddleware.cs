using BeHealthBackend.Configurations.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace BeHealthBackend.Configurations.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ForbidException forbidException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(forbidException.Message);
            }
            catch (Exceptions.BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            var message = "A problem happened while handling your request.";

            switch (exception)
            {
                case NotFoundApiException:
                    statusCode = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
            }

            _logger.LogError(exception, $"An error occurred: {exception.Message}");

            ProblemDetails problemDetails = new()
            {
                Status = (int)statusCode,
                Type = "Error",
                Title = message
            };

            var resultJson = JsonSerializer.Serialize(problemDetails);

            var response = context.Response;

            response.StatusCode = (int)statusCode;

            response.ContentType = "application/json";

            await response.WriteAsync(resultJson);
        }
    }
}
