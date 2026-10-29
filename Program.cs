
namespace EdgePanel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapFallback(NotFoundHandler);
            app.Run();
        }

        private static async Task NotFoundHandler(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
