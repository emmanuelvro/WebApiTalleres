using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebApiTalleres.Filters
{
    public class GlobalExceptionFilter
    {
        private readonly RequestDelegate next;

        public GlobalExceptionFilter(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var status = HttpStatusCode.InternalServerError;
            var code = string.Empty;
            object values = null;
            if (exception is GenericException exception1)
            {
                status = HttpStatusCode.BadRequest;
                code = exception1.Code;
                values = exception1.Values;
            }
            var jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var result = JsonConvert.SerializeObject(new { code, exception.Message, values }, jsonSettings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsync(result);

            return;
        }
    }
}
