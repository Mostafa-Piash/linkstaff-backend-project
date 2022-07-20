using SocialNetwork.Persistence;
using SocialNetwork.Core;
using SocialNetwork.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(configuration);
builder.Services.AddServices();
builder.Services.AddRepositories();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
