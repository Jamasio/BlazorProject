using BlazorProject.Components;
using BlazorProject.Services.RefData;

var builder = WebApplication.CreateBuilder(args);

var signalR = builder.Configuration["Azure:SignalR:ConnectionString"];

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Added SignalR
builder.Services.AddSignalR().AddAzureSignalR(signalR);
// Added DataManagement
builder.Services.AddSingleton<IRefDataService, RefDataServiceMock>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
