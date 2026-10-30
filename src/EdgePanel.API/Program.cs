using EdgePanel.Filter;
using EdgePanel.Model.Response;
using Microsoft.AspNetCore.Mvc.Infrastructure;

public partial class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers(
            options =>
            {
                options.Filters.Add<ResponseFilter>();
            }
        );
        builder.Services.AddOpenApi();
        WebApplication app = builder.Build();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.MapFallback("{*path}", (HttpContext http, ProblemDetailsFactory problems) =>
            Results.Json(
                new APIError<object?> { Error = problems.CreateProblemDetails(http, StatusCodes.Status404NotFound).Title },
                statusCode: StatusCodes.Status404NotFound));
        app.Run();
    }
}