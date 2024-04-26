using EKtu.Persistence;
using EKtu.Repository.Dtos;
using EKtu.WEBAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(y => y.UseSqlServer(builder.Configuration.GetConnectionString("mydb"))); //burada kald�m
builder.Services.AddedService();
builder.Services.Configure<Configuration>(builder.Configuration.GetSection("Configuration"));
builder.Services.AddSingleton<IRedisClient>(y =>
{
   var ClientManager=  new RedisManagerPool(builder.Configuration.GetConnectionString("redis"));
   return ClientManager.GetClient();
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.Authority = "https://localhost:7134";
    x.Audience = "BaseApi";
});
builder.Services.AddOptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
