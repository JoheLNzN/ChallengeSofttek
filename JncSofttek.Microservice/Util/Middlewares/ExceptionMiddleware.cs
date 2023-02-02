using JncSofttek.Microservice.Common.Classes;
using JncSofttek.Microservice.Common;
using JncSofttek.Microservice.Repository.Repositories.Dtos.User;
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JncSofttek.Microservice.Controllers;
using Newtonsoft.Json.Serialization;
using System;

namespace JncSofttek.Microservice.Util.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger) => (_next, _logger) = (next, logger);

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var stackTrace = ex.StackTrace;
                var method = stackTrace.Split(Environment.NewLine)[0];

                _logger.LogError("#################  GLOBAL ERROR :\n $ [{0}] \n $ {1}",
                method, ex.ToString());

                await HandleExceptionAsync(httpContext);
            }
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return context.Response.WriteAsync(
                JsonConvert.SerializeObject(new DefaultResponse<string>(false,
                    errorMessage: AppConsts.STATUS_CODE_500_INTERNAL_SERVER_ERROR),
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
        }
    }
}
