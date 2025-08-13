var builder = WebApplication.CreateBuilder(args);

// Orchard Core + AutoSetup
builder.Services
	.AddOrchardCms()
	.AddSetupFeatures("OrchardCore.AutoSetup");

var app = builder.Build();

// Orchard Core pipeline
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseOrchardCore();

app.Run();
