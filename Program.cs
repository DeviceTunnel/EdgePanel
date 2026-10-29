using EdgePanel.Filters;

namespace EdgePanel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IProblemDetailsWriter, EnvelopeProblemDetailsWriter>();
            builder.Services.AddControllers(o => o.Filters.Add<ApiEnvelopeFilter>());
            builder.Services.AddProblemDetails();
            builder.Services.AddOpenApi();
            WebApplication app = builder.Build();
            app.UseExceptionHandler();
            app.UseStatusCodePages();
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
