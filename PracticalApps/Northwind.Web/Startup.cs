﻿namespace Northwind.Web;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseHsts();
        }
        app.UseRouting(); // start endpoint routing
        app.UseHttpsRedirection();
        app.UseEndpoints(EndpointDataSource =>
        {
            EndpointDataSource.MapGet("/", () => "Hello World!");
        });
    }
}
