using LoginApp.IdenttiyClasses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
// OR
//builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
//This line configures authentication services for your application. It adds the
//Bearer token authentication scheme (IdentityConstants.BearerScheme), which is commonly used for securing APIs.
//builder.Services.AddAuthentication();
//This line adds services required for authorization, allowing you to define and enforce access
//policies within your application.

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddIdentityCore<MyUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.MapIdentityApi<MyUser>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
