
using JSdotNet.Blog.Infrastructure.EF;
using JSdotNet.Blog.Infrastructure.EF.Data;
using JSdotNet.Host.Components;
using JSdotNet.ServiceDefaults;

using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);


//builder.WebHost.UseKestrelHttpsConfiguration(); // TODO Is this a service default?

// Add service defaults & Aspire components.
//builder.AddServiceDefaults();
//builder.AddRedisOutputCache("cache");

// WEB
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddFluentUIComponents();
// TODO May be interesting for CRUD app ... builder.Services.AddDataGridEntityFrameworkAdapter();


// API
// Add services to the container.
builder.Services.AddProblemDetails();


// Modules
// TODO: Move to Infrastructure project or Service Defaults?
builder.AddSqlServerDbContext<DataContext>
(
    "sqldata",
    static settings => settings.ConnectionString = "DATABASE"
);
// TODO: How to add interceptors, etc.?
builder.Services.AddInfrastructureEf(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

//app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(JSdotNet.Host.AssemblyReference.AdditionalAssemblies);


var blogModule = "/blog"; // TODO Forward to module
app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments(blogModule, StringComparison.OrdinalIgnoreCase), first =>
{
    first.UseBlazorFrameworkFiles(blogModule);
    first.UseStaticFiles();
    first.UseStaticFiles(blogModule);
    first.UseRouting();

    first.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers(); // TODO Replace with Endpoints
        endpoints.MapFallbackToFile("{blogModule}/{*path:nonfile}", $"{blogModule}/index.html"); // TODO ...
    });
});

//app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/SecondApp",
//    StringComparison.OrdinalIgnoreCase), second =>
//{
//    second.UseBlazorFrameworkFiles("/SecondApp");
//    second.UseStaticFiles();
//    second.UseStaticFiles("/SecondApp");
//    second.UseRouting();

//    second.UseEndpoints(endpoints =>
//    {
//        endpoints.MapControllers();
//        endpoints.MapFallbackToFile("/SecondApp/{*path:nonfile}",
//            "SecondApp/index.html");
//    });
//});

// TODO Module endpoints + connection from client project
//app.MapDefaultEndpoints();

app.Run();


// TODO ???
// - https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/multiple-hosted-webassembly?view=aspnetcore-7.0&pivots=route-subpath
// - https://gorillalogic.com/blog/four-micro-frontend-architecture-types-you-can-implement-with-blazor