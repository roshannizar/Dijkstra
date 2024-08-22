using Dijkstra.Api.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var configuration = builder.Configuration;

services.AddCoreExtension();
services.AddSwaggerGen();
services.AddAppExtension(configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddCoreMiddleware();
app.AddSecurityMiddleware();

app.MapControllers();

app.Run();
