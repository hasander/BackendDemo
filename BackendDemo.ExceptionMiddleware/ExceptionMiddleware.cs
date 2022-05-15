using BackendDemo.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BackendDemo.ExceptionMiddleware;
public class ExceptionMiddleware


{
    private readonly RequestDelegate _nextMiddleWare;
    private readonly IHostingEnvironment _hostingEnvironment;

    public ExceptionMiddleware(RequestDelegate next,  IHostingEnvironment hostingEnvironment)
    {
        _nextMiddleWare = next;
        _hostingEnvironment = hostingEnvironment;
    }


    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _nextMiddleWare(httpContext);
        }
        catch (Exception ex)
        {
            //todo Added Logg
            await HandleExceptionAsync(httpContext);
        }

    }
    private Task HandleExceptionAsync(HttpContext context)
    {
        var appResponse = new AppResponse("Sistemsel bir hata oluştu lütfen sonra tekrar deneyiniz.") { Status = ResponseStatus.ERROR };

        var result = JsonConvert.SerializeObject(appResponse, new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        });
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(result);
    }
}