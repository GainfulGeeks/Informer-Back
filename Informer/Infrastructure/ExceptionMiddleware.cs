using Informer.Utilities;

namespace Informer.Infrastructure
{
    public static class ExceptionMiddleware
    {
        public static async Task Handle(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var message =Utility.SetLog(ex.Message);

                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsync(message);
            }
        }
    }
}