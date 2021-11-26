using API.Domain;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Middlewares
{
    internal class ResponseErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (OperationCanceledException)
            {
                context.Response.StatusCode = 204;
            }
            catch (ValidationException ex)
            {
                JsonOptions jsonOptions = new JsonOptions();
                jsonOptions.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                string result = string.Empty;

                if (ex.Errors.Any())
                    result = JsonConvert.SerializeObject(ex.Errors.Select(f =>
                    {
                        string fieldName = jsonOptions?.JsonSerializerOptions?.PropertyNamingPolicy?.ConvertName(f.PropertyName);
                        return new JsonError(fieldName, f.ErrorMessage);
                    }), new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                else
                    result = JsonConvert.SerializeObject(new { errorMessage = ex.Message });

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                await ResponseError(context, ex);
            }
        }

        private async Task ResponseError(HttpContext context, Exception ex)
        {
            string result = JsonConvert.SerializeObject(new
            {
                errorMessage = "Ocorreu um erro durante a solicitação"
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            await context.Response.WriteAsync(result);
        }
    }
}