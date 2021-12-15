

using Microsoft.EntityFrameworkCore;
using WebApi.Abstractions;
using WebApi.DataAccess;
using WebApi.Services;

var DevAllowedOriginsPolicyName = "_devAllowedOriginsPolicyName";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite($"Data Source=UserDB.db;"));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserDA, UserDA>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DevAllowedOriginsPolicyName,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:5002")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseCors(DevAllowedOriginsPolicyName);
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
