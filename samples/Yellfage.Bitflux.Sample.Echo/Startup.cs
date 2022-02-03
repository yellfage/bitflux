using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Yellfage.Bitflux.Receptions.WebSockets;
using Yellfage.Bitflux.Protocols.NewtonsoftJson;

namespace Yellfage.Bitflux.Sample.Echo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors();

            services
                .AddBitfluxHub<EchoHub>()
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

                endpoints.MapBitfluxHub<EchoHub>("/ws", configurator =>
                {
                    configurator.UseWebSocketReception();
                });
            });
        }
    }
}
