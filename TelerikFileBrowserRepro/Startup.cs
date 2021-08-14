using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;

namespace TelerikFileBrowserRepro
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers()
        .AddNewtonsoftJson(options =>
         {
           options.SerializerSettings.ContractResolver = new DefaultContractResolver();
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
         });

      services
        .AddRazorPages();

      // Add the Kendo UI services to the services container.
      services.AddKendo();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseStaticFiles();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapRazorPages();
      });
    }
  }
}
