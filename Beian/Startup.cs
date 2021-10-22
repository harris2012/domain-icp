using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Beian
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            Dictionary<string, Domain> domains = new Dictionary<string, Domain>();
            domains.Add("www.sample.cn", new Domain { Title = "111", ICP = "沪ICP备000号-1" });
            domains.Add("www.demo.com", new Domain { Title = "222", ICP = "沪ICP备0006号-3" });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var host = context.Request.Host.Host;

                    if (domains.ContainsKey(host))
                    {
                        await context.Response.WriteAsync(new Template { Domain = domains[host] }.TransformText(), Encoding.UTF8);
                        return;
                    }

                    if (domains.ContainsKey("www." + host))
                    {
                        await context.Response.WriteAsync(new Template { Domain = domains["www." + host] }.TransformText(), Encoding.UTF8);
                        return;
                    }

                    await context.Response.WriteAsync($"<!--{host}-->");
                });
            });
        }
    }
}
