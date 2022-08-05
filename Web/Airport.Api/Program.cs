// <copyright file="Program.cs" company="Airport">
// Copyright (c) Airport. All rights reserved.
// Licensed under the Proprietary license. See LICENSE file in the project root for full license information.
// </copyright>

using Airport.Application.Extensions;
using Airport.Application.Middlewares;
using Airport.Infrastructure.Localization;
using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Add other extensions.
builder.Services.AddSwagger();
builder.Services.RegisterServices();
builder.Services.AddCorsServices();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddLocalizer((options) =>
{
    options.DefaultCulture = "en-US";
    options.ResourcesPath = "wwwroot/resources/";
    options.SupportedCultures = new string[] { "en-US", "tr-TR" };
});

// add serilog
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airport.Api v1"));
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseStaticFiles();
app.UseMiddleware<ExceptionMiddleware>();
app.UseRequestLocalization();

var env = app.Environment;

string rootPath = null;
app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/robots.txt"), b =>
    b.UseMiddleware<RobotsTxtMiddleware>(env.EnvironmentName, rootPath ?? env.ContentRootPath));

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
