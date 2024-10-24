using Microsoft.AspNetCore.Cors.Infrastructure;
using RummyAi.WebApi.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddFilter();
builder.Services.AddOption();
builder.Services.AddSignalR();

builder.Services.AddCorsSettings();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsOptions");

app.AddHubs();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();