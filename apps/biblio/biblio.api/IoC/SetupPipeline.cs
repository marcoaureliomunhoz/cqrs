using Microsoft.AspNetCore.Builder;

namespace biblio.api.IoC
{
    public static class SetupPipeline
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblio API v1");
            });
        }
    }
}