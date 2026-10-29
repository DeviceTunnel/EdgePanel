using EdgePanel.Response;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EdgePanel.Filters
{
    public class EnvelopeProblemDetailsWriter(ProblemDetailsFactory factory) : IProblemDetailsWriter
    {
        public bool CanWrite(ProblemDetailsContext context) => true;
        public ValueTask WriteAsync(ProblemDetailsContext context)
        {
            var http = context.HttpContext;
            var p = context.ProblemDetails;
            var problem = factory.CreateProblemDetails(http, p.Status ?? http.Response.StatusCode, p.Title, p.Type, p.Detail, p.Instance);
            return new ValueTask(http.Response.WriteAsJsonAsync<object>(new ErrorResponse<object>(problem)));
        }
    }
}
