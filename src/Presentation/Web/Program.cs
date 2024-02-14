using JSdotNet.Web.Components;
using JSdotNet.ServiceDefaults;

using Microsoft.FluentUI.AspNetCore.Components;


var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
//builder.AddServiceDefaults();
//builder.AddRedisOutputCache("cache");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//builder.Services.AddHttpClient<WeatherApiClient>(client=> client.BaseAddress = new("http://apiservice"));

// Add FluentUI
builder.Services.AddFluentUIComponents();
// TODO May be interesting for CRUD app ... builder.Services.AddDataGridEntityFrameworkAdapter();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
//app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(JSdotNet.Web.Client.AssemblyReference.Assembly);

//app.MapDefaultEndpoints();

app.Run();
