using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = new
            {
                ErrorCode = GetErrorCode(exception),
                ErrorMessage = GetErrorMessage(exception),
                Timestamp = DateTime.UtcNow
            };

            response.StatusCode = GetStatusCode(exception);

            _logger.LogError(exception, "An error occurred: {Message}", exception.Message);

            await response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }

        private string GetErrorCode(Exception exception)
        {
            return exception switch
            {
                BadRequestException badRequest => badRequest.ErrorCode,
                UnauthorizedAccessException => "UNAUTHORIZED",
                _ => "INTERNAL_SERVER_ERROR"
            };
        }

        private string GetErrorMessage(Exception exception)
        {
            return exception switch
            {
                BadRequestException badRequest => badRequest.ErrorMessage,
                UnauthorizedAccessException => "Acesso não autorizado",
                _ => "Ocorreu um erro interno no servidor"
            };
        }

        private int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                BadRequestException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }
    }
}