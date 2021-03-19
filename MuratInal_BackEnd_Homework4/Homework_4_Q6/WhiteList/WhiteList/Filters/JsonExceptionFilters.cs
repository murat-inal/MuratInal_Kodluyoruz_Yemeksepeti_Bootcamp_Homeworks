using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WhiteList.Filters
{
    public class JsonExceptionFilters : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError
            {
                Detail = context.Exception.StackTrace,
                Message = "Unauthorized IP address"
            };

            context.Result = new ObjectResult(error) { StatusCode = 403 };
        }
    }
}
