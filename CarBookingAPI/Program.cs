using CarBookingAPI.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

//builder.Services.Configure<EmailSenderController>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
var smptSettings = app.Configuration.GetSection("SmptSettings");

// подключаем CORS
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
