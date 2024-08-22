using Dijkstra.Shared.Api.Models;
using System.Net;
using System.Text.Json;

namespace Dijkstra.Api.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger logger;

        public ErrorMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            this.logger = logger.CreateLogger("ErrorLog");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ErrorModel { Succeeded = false, Message = ex?.Message };
                logger.LogError(ex.Message);

                switch (ex)
                {
                    case NullReferenceException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Errors = e.Message;
                        break;
                    default:
                        if (ex.InnerException == null)
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseModel.Errors = ex.Message;
                        }
                        else
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseModel.Errors = ex.InnerException.Message;
                        }
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
