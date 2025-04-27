using System;
using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace RO.DevTest.Domain.Exception;

// [TODO] Standardize requests
// [TODO] Display a semantic error message to the client
/// <summary>
/// Returns a <see cref="HttpStatusCode.BadRequest"/> to
/// the request
/// </summary>
public class BadRequestException : System.Exception
{
    public string ErrorCode { get; }
    public string ErrorMessage { get; }
    public HttpStatusCode StatusCode { get; }

    public BadRequestException(string errorCode, string errorMessage)
        : base(errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
        StatusCode = HttpStatusCode.BadRequest;
    }

    public BadRequestException(string errorMessage)
        : this("BAD_REQUEST", errorMessage)
    {
    }

    public BadRequestException(IdentityResult result)
        : base(result.ToString())
    {
        ErrorCode = "BAD_REQUEST";
        ErrorMessage = result.ToString();
        StatusCode = HttpStatusCode.BadRequest;
    }

    public BadRequestException(ValidationResult validationResult)
        : base(validationResult.ToString())
    {
        ErrorCode = "BAD_REQUEST";
        ErrorMessage = validationResult.ToString();
        StatusCode = HttpStatusCode.BadRequest;
    }
}
