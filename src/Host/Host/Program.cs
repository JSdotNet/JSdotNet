
using JSdotNet.Blog.Infrastructure.EF;
using JSdotNet.Blog.Infrastructure.EF.Data;
using JSdotNet.Host.Components;
using JSdotNet.ServiceDefaults;

using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);


//builder.WebHost.UseKestrelHttpsConfiguration(); // TODO Is this a service default?

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");

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

app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(JSdotNet.Host.AssemblyReference.AdditionalAssemblies);

// TODO Module endpoints + connection from client project
app.MapDefaultEndpoints();

app.Run();
