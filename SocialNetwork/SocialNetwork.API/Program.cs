using SocialNetwork.Persistence;
using SocialNetwork.Core;
using SocialNetwork.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Common;
using SocialNetwork.API.Extensions;

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

var app = builder.Build();
await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<SocialNetworkDbContext>();
await db.Database.MigrateAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
