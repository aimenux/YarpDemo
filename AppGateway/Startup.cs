using System;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppGateway;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddHttpLogging(options =>
        {
            options.LoggingFields = HttpLoggingFields.All;
            options.CombineLogs = true;
        });
        
        services.AddOutputCache(options => 
        {
            options.AddPolicy(Constants.OutputCachePolicyName, builder => 
            {
                builder.Expire(TimeSpan.FromSeconds(1));
            });
        });
        
        services.AddRateLimiter(rateLimiterOptions =>
        {
            rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            rateLimiterOptions.AddFixedWindowLimiter(Constants.RateLimitingPolicyName, options =>
            {
                options.PermitLimit = 5;
                options.Window = TimeSpan.FromSeconds(10);
                options.QueueLimit = 0;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            });
        });

        services
            .AddReverseProxy()
            .LoadFromConfig(configuration.GetSection(Constants.ReverseProxySectionName));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpLogging();

        app.UseHttpsRedirection();
        
        app.UseRouting();
        
        app.UseAuthentication();

        app.UseAuthorization();
        
        app.UseOutputCache();
        
        app.UseRateLimiter();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("", ctx => ctx.Response.WriteAsync("App Gateway"));
            endpoints.MapReverseProxy().CacheOutput(Constants.OutputCachePolicyName);
        });
    }
}