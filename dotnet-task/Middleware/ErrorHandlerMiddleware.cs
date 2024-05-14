using dotnet_task.Exceptions;
using dotnet_task.Responses;
using System.Net;

namespace dotnet_task.Middleware
{
   

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;


        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                Dictionary<string, string[]> errors = new Dictionary<string, string[]>();
                errors.Add("Error", new string[] { error.Message });

                if (error.InnerException != null)
                {
                    errors.Add("Error", new string[] { error.InnerException.Message });
                }

                var response = context.Response;

                response.ContentType = "application/json";

                var responseModel = new Response<string>() { Succeeded = false, Message = "An error occurred!", Errors = errors };

                switch (error)
                {
                    case CustomException e:

                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel = new Response<string>() { Succeeded = false, Message = error.Message, Errors = errors };

                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        break;
                }
                var result = System.Text.Json.JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
