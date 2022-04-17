using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApp
{
    public static class WebServiceEndpoint
    {
        public static string BaseUrl = "api/products";

        public static void MapWebService(this IEndpointRouteBuilder builder)
        {
            builder.MapGet($"{BaseUrl}/{{id}}", async context =>
            {
                long key = long.Parse(context.Request.RouteValues["id"] as string ?? string.Empty);
                DataContext dataContext = context.RequestServices.GetService<DataContext>();
                Product p = dataContext.Products.Find(key);
                if (p == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize<Product>(p));
                }
            });

            builder.MapGet(BaseUrl, async context =>
            {
                DataContext dataContext = context.RequestServices.GetService<DataContext>();
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(dataContext.Products));
            });

            builder.MapPost(BaseUrl, async context =>
            {
                DataContext dataContext = context.RequestServices.GetService<DataContext>();
                Product p = await JsonSerializer.DeserializeAsync<Product>(context.Request.Body);
                await dataContext.AddAsync(p);
                await dataContext.SaveChangesAsync();
                context.Response.StatusCode = StatusCodes.Status200OK;
            });
        }
    }
}