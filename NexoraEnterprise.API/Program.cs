using NexoraEnterprise.API.Extensions;
using NexoraEnterprise.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();      // Optional: built-in OpenAPI
builder.Services.AddSwaggerGen();   // Swagger

builder.Services.AddInfrastructure(builder.Configuration);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();      // Optional: exposes /openapi/v1.json

    app.UseSwagger();      // Generates /swagger/v1/swagger.json
    app.UseSwaggerUI();    // Serves Swagger UI at /swagger
}

app.UseCorrelationId();

app.UseRequestLogging();

app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();