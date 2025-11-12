using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApiGateway.Presintaion.Middelware
{
    public class AttachSignatureToRequest
    {
        private readonly RequestDelegate _next;

        public AttachSignatureToRequest(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Add a custom header
            context.Request.Headers["Api-Gateway"] = "Signed";

            // Continue the request pipeline
            await _next(context);
        }
    }
}
