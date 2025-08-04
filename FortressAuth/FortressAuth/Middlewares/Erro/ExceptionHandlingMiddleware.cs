using FortressAuth.Application.DTOs.Responses.Erro;
using System.Net;

namespace FortressAuth.Middlewares.Erro
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex, context);
            }
        }

        public async Task HandleExceptionAsync(Exception ex, HttpContext context)
        {
            ErroExceptionBase erroExceptionBase;
            switch (ex)
            {
                case ArgumentException argumentException:
                    erroExceptionBase = new ErroExceptionBase(HttpStatusCode.BadRequest, argumentException.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case CustomException customException:
                    erroExceptionBase = new ErroExceptionBase(HttpStatusCode.BadRequest, customException.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    erroExceptionBase = new ErroExceptionBase(HttpStatusCode.InternalServerError, "An unexpected error occurred.");
                    break;
            }

            await context.Response.WriteAsJsonAsync(erroExceptionBase);
        }
    }
}
