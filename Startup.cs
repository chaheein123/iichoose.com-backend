using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ichoose_api
{
  public class Startup
  {
    private string _yelpApiKey = null;

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      _yelpApiKey = Configuration["App:YelpAPI"];
      services.AddCors();
      services.AddControllers();
      services.AddHttpClient("yelp", c => {
        c.BaseAddress = new Uri("https://api.yelp.com/v3/businesses/search");
        c.DefaultRequestHeaders.Add("Authorization", _yelpApiKey);
      });
      services.AddMvc().AddNewtonsoftJson();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
          
      }
      app.UseCors(options =>
      {
        options.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod();

      });

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
