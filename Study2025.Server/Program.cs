using GrpcService; // или Study2025.Server.Services
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Study2025.Server;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://+:44333");

// Регистрация сервисов
builder.Services.AddControllers();
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TestRepository>();
builder.Services.AddScoped<TestRepositoryDapper>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddHttpClient();
builder.Services.AddHealthChecks()
    .AddCheck("sample", () => HealthCheckResult.Healthy("OK"));

var app = builder.Build();

// Настройка pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAngular");
app.UseAuthorization();

app.MapGrpcService<GreeterService>();
app.MapControllers();
app.MapHealthChecks("/healthz");

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

// Убедись, что это не мешает gRPC
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToFile("/index.html");

app.Run();