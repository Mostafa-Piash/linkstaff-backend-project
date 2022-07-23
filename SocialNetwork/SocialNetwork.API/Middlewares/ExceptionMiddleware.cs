using Newtonsoft.Json;
using SocialNetwork.Domain.Common;
using System.Net;

namespace SocialNetwork.API.Middlewares
{
    public class ExceptionMiddleware : DelegatingHandler
    {

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Items["Exception"] = ex;
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response<dynamic> response = new();
            response.Message = "Internal server error, please contact with developent team";
            response.Success = false;
            _logger.LogError(exception.Message, exception);
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }


}
