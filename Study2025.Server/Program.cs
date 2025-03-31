using Microsoft.Extensions.Diagnostics.HealthChecks;
using Study2025.Server;

var builder = WebApplication.CreateBuilder(args);

//string connectionString = string.Empty;
//if (builder.Environment.IsDevelopment())
//{
//    connectionString = builder.Configuration.GetConnectionString("DefaultConnection").
//        Replace("host.docker.internal", "localhost");
//}
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(connectionString));

builder.WebHost.UseUrls("http://+:5000"); // Разрешает слушать на всех интерфейсах

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TestRepository>();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngularDev",
//        builder => builder
//            .WithOrigins("https://localhost:7158")
//            .AllowAnyMethod()
//            .AllowAnyHeader());
//});

builder.Services.AddHealthChecks()
    .AddCheck("sample", () => HealthCheckResult.Healthy("OK")); // Простая проверка


var app = builder.Build();

app.MapHealthChecks("/healthz");

app.UseDefaultFiles();
app.UseStaticFiles();
//app.UseCors("AllowAngularDev");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
);

//app.UseCors(policy =>
//    policy.WithOrigins("http://localhost:4200")
//          .AllowAnyMethod()
//          .AllowAnyHeader()
//);

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
