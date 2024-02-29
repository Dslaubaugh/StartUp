using Microsoft.OpenApi.Models;
using StartUp.Web.models;
using StartUp.Web.services;

namespace StartUp.Web;

public class Startup
{
 private readonly IConfiguration _configuration;
    public static IConfiguration StaticConfig { get; private set; }
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
        StaticConfig = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var appSettings = _configuration.Get<AppSettings>();
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "StartUpApp", 
                Version = "v1",
            });
        });
        
       
        services.AddTransient<IStartUpService,StartUpService>();

        services.AddSingleton(appSettings);
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        var appSettings = _configuration.Get<AppSettings>();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "StartUpApp v1");            
            c.OAuthUsePkce();
        });
        
        app.UseStaticFiles();
        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseCors("AllowAllOrigins");
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}