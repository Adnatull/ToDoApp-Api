using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ToDoApp.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\CleanArchitecture.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo App - Implementation of Clean Architecture",
                    Description = "This contains cqrs,mediaTr, onion architecture, Exception handling, Entity Framework Core - Code First, Repository Pattern - Generic, Swagger UI, Response Wrappers, Pagination, API Versioning,Automapper, Serilog",
                    Contact = new OpenApiContact
                    {
                        Name = "Adnatull Al Masum",
                        Email = "adnatull@dimikit.net",
                        Url = new Uri("http://adnatull.github.io"),
                    }
                });
          
            });
        }
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {

            #region API Versioning
            // Add API Versioning to the Project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
            #endregion
        }
    }
}
