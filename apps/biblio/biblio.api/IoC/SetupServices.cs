using System.Reflection;
using biblio.api.Domain._Shared.Pipelines;
using biblio.api.Domain.Books.Repositories;
using biblio.api.Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace biblio.api.IoC
{
   public static class SetupServices
   {
      public static void ConfigureCors(this IServiceCollection services)
      {
         services.AddCors(options =>
         {
            options.AddPolicy(
                  "*",
                  builder =>
                     builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
            );
         });
      }

      public static void ConfigureSwagger(this IServiceCollection services)
      {
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Biblio API", Version = "v1" });
            c.CustomSchemaIds(x => x.FullName);
         });
      }

      public static void ConfigureMediatR(this IServiceCollection services)
      {
         services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MeasureTime<,>));
         services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateCommand<,>));

         services.AddMediatR(typeof(Startup));
      }

      public static void ConfigureRepositories(this IServiceCollection services)
      {
         services.AddSingleton(new BookRepository());

         var serviceProvider = services.BuildServiceProvider();
         var bookRepository = serviceProvider.GetService<BookRepository>();

         services.AddSingleton<IBookWrite>(bookRepository);
         services.AddSingleton<IBookRead>(bookRepository);
      }
   }
}