var builder = WebApplication.CreateBuilder(args);

//builder.Logging.ClearProviders();
//builder.Host.UseNLogHost();

var configuration = builder.Configuration;

// Register ConfigurationManager instance
builder.Services.AddSingleton(configuration).AddOrchardCms();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}

app.UseOrchardCore();

await app.RunAsync();

public partial class Program
{
	protected Program()
	{
		// Nothing to do here.
	}
}
