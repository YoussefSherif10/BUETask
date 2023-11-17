using Backend.Controllers.Filters;
using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder
    .Services
    .AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder
    .Services
    .AddCors(options =>
    {
        options.AddPolicy(
            "CorsPolicy",
            builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        );
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            await context
                .Response
                .WriteAsync(
                    new ErrorDetails
                    {
                        StatusCode = contextFeature.Error switch
                        {
                            InvalidOperationException => StatusCodes.Status404NotFound,
                            BadHttpRequestException => StatusCodes.Status400BadRequest,
                            DbUpdateException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        },
                        Message = 
                        contextFeature.Error is DbUpdateException ? 
                            "The entered email already exists" :
                            contextFeature.Error.Message
                    }.ToString()
                );
        }
    });
});

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");


app.MapControllers();

app.Run();
