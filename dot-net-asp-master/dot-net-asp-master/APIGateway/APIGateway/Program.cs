using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);


IConfiguration config = new ConfigurationBuilder().AddJsonFile("Ocelot.json").Build();
builder.Services.AddOcelot(config).AddConsul();
var app = builder.Build();
app.UseOcelot();
//configuration required for using ocelot
//template avaliable
 app.MapGet("/", () => "Hello World!");

app.Run();
