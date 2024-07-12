WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration).AddInfrastructureServices(builder.Configuration).AddApiServices(builder.Configuration);//DependencyInjection.cs

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();//DependencyInjection.cs dosyasýndaki metot.

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
