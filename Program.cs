using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaHotel.Context;
using PruebaHotel.Services;
using PruebaHotel.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddDbContext<HotelContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("db")));

builder.Services.AddScoped<IDataAccesHotelService, SQLDataAccesHotelService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient",
        b =>
        {
            b
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularDevClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
