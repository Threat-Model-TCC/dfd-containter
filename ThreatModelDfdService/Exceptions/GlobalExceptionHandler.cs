namespace ThreatModelDfdService.Exceptions;

internal sealed class GlobalExceptionHandler(
    RequestDelegate next,
    ILogger<GlobalExceptionHandler> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred while processing the request.");

            var statusCode = ex switch
            {
                ApplicationException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                Type = ex.GetType().Name,
                Detail = ex.Message,
                Status = statusCode,
                Endpoint = context.Request.Path
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
