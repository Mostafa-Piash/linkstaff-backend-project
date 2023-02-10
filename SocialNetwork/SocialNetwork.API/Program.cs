using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SocialNetwork.API.Extensions;
using SocialNetwork.API.Middlewares;
using SocialNetwork.Core;
using SocialNetwork.Domain.Common;
using SocialNetwork.Persistence;
using SocialNetwork.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(configuration);
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.Configure<JwtConfiguration>(configuration.GetSection(nameof(JwtConfiguration)));
builder.Services.AddJwtAuthentication(configuration);
builder.Services.AddSwaggerGen(c =>
{

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement();
    securityRequirement.Add(securitySchema, new[] { "Bearer" });
    c.AddSecurityRequirement(securityRequirement);
});
var app = builder.Build();
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<SocialNetworkDbContext>();
await db.Database.MigrateAsync();


app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
