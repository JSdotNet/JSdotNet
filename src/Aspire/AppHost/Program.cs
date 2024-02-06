
var builder = DistributedApplication.CreateBuilder(args);

var appInsightsConnectionString =
    builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];


builder.AddContainer("structurizr", "structurizr/lite")  // Alternative docker image: structurizr/onpremises
    .WithVolumeMount("../../../doc", "/usr/local/structurizr", VolumeMountType.Bind)
    //.WithEnvironment("structurizr.autoRefreshInterval", "2000")
    //.WithEnvironment("structurizr.autoSaveInterval", "5000")
    //.WithEnvironment("structurizr.darkMode", "2000")
    .WithServiceBinding(containerPort: 8080, hostPort: 8080, name: "structurizr-http", scheme: "http");

//var grafana = builder.AddContainer("grafana", "grafana/grafana")
//    .WithVolumeMount("../grafana/config", "/etc/grafana")
//    .WithVolumeMount("../grafana/dashboards", "/var/lib/grafana/dashboards")
//    .WithServiceBinding(containerPort: 3000, hostPort: 3000, name: "grafana-http", scheme: "http");

//builder.AddProject("test", t => t)
//builder.Services.AddHttpClient("Application Insights",
//    static client => client.BaseAddress = new("https://portal.azure.com/#@innovadis.com/resource/subscriptions/4b2f19dd-b4b3-487c-a5c6-a996593ab8d2/resourcegroups/Develop/providers/microsoft.insights/components/Develop/overview"));


var cache = builder.AddRedisContainer("cache");

var sql = builder.AddSqlServer("sql")
    .AddDatabase("sqldata");

var apiservice = builder.AddProject<Projects.Api>("apiservice")   
    .WithReference(sql)
    .WithEnvironment("APPLICATIONINSIGHTS_CONNECTION_STRING", appInsightsConnectionString);

builder.AddProject<Projects.Presentation_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiservice)
    .WithEnvironment("APPLICATIONINSIGHTS_CONNECTION_STRING", appInsightsConnectionString);


builder.Build().Run();



// https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/components-overview?tabs=dotnet-cli

// TODO ...
// Key fault: https://learn.microsoft.com/en-us/dotnet/aspire/security/azure-security-key-vault-component?tabs=dotnet-cli
// AppInsights: https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/application-insights


// Samples: https://github.com/dotnet/aspire-samples/tree/main/samples
// https://my.visualstudio.com/Benefits?wt.mc_id=o~msft~profile~devprogram_attach&workflowid=devprogram&mkt=en-us
// Cost: https://portal.azure.com/#@innovadis.com/resource/subscriptions/4b2f19dd-b4b3-487c-a5c6-a996593ab8d2/resourceGroups/Develop/costanalysis
// Application Insights: https://portal.azure.com/#@innovadis.com/resource/subscriptions/4b2f19dd-b4b3-487c-a5c6-a996593ab8d2/resourcegroups/Develop/providers/microsoft.insights/components/Develop/overview