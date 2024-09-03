using SaleSystem.Front.Components;
using Shared.Services.Interfaces;
using Shared.Services.Classes;
using Shared.Utilities.Mappers.Interfaces;
using Shared.Utilities.Mappers.Classes;

var builder = WebApplication.CreateBuilder(args);

#region Services
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("SaleSystemApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7264/api/");
});

#region Services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISaleService, SaleService>();
#endregion Services

#region Mappers
builder.Services.AddScoped<IClientMappers, ClientMappers>();
builder.Services.AddScoped<ICategoryMappers, CategoryMappers>();
builder.Services.AddScoped<IProductMappers, ProductMappers>();
builder.Services.AddScoped<ISaleMappers, SaleMappers>();
#endregion Mappers

#endregion Services

var app = builder.Build();

#region Middlewares
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

#endregion Middlewares

app.Run();
