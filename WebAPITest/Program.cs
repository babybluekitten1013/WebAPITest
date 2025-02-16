using WebAPITest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPITest.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using WebAPITest.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// links the DB
builder.Services.AddDbContext<WebAPITestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAPITestContext") ?? throw new InvalidOperationException("Connection string 'WebAPITestContext' not found.")));

// links up id
builder.Services.AddDefaultIdentity<ContentUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebAPITestContext>();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true; 
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
