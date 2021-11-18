using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Yellfage.Wst.Receptions.WebSockets;
using Yellfage.Wst.Protocols.NewtonsoftJson;

namespace Yellfage.Wst.Sample.Echo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors();

            services
                .AddWstHub<EchoHub>()
                .AddWebSocketReception()
                .AddNewtonsoftJsonProtocol();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(o => o.AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapWstHub<EchoHub>("/ws", configurator =>
                {
                    configurator.UseWebSocketReception();
                });
            });
        }
    }
}
