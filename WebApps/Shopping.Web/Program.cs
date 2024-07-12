WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddRefitClient<ICatalogService>().ConfigureHttpClient(c => { c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!); });
builder.Services.AddRefitClient<IBasketService>().ConfigureHttpClient(c => { c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!); });
builder.Services.AddRefitClient<IOrderingService>().ConfigureHttpClient(c => { c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!); });

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
