using EdgePanel.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdgePanel.Filters
{
    public class ApiEnvelopeFilter : IAsyncAlwaysRunResultFilter
    {
        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult result
                && result.Value is not DataResponse<object?> and not ErrorResponse<object>)
            {
                result.Value = result.Value is ProblemDetails problem
                    ? new ErrorResponse<object>(problem)
                    : new DataResponse<object?>(result.Value);
                result.ContentTypes.Clear();
            }
            return next();
        }
    }
}
