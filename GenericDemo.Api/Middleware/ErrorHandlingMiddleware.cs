namespace GenericDemo.Api.Middlewares
{
    using System.Linq;
    using System.Threading.Tasks;

    using GenericDemo.Domain.Exceptions;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Routing;

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (EntityNotFoundException ex)
            {
                var response = new NotFoundObjectResult(ex.Message);
                await response.ExecuteResultAsync(
                    new ActionContext(context, context.GetRouteData(), new ActionDescriptor()));
            }
            catch (EntityValidationException ex)
            {
                var response = new BadRequestObjectResult($"{ex.Message}, {string.Join(", ", ex.Errors.Select(x => x.ErrorMessage))}");
                await response.ExecuteResultAsync(
                    new ActionContext(context, context.GetRouteData(), new ActionDescriptor()));
            }
        }
    }
}