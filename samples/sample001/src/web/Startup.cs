using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("All was good!");
            });
        }
    }
}