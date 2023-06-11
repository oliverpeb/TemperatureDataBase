using Microsoft.EntityFrameworkCore;
using Temperature.Repositories;
using Temperature.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

const string policyName = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
});

//Add DbContext using connection string from configuration
builder.Services.AddDbContext<TempDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TempDbConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

bool useSql = true;
if (useSql)
{
    builder.Services.AddScoped<ITempRepository, TempDbRepository>();
}
else
{
    builder.Services.AddSingleton<ITempRepository, TempRepository>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
