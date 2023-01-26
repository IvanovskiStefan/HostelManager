using HostelManager;
using HostelManager.Domain;
using HostelManager.Repositories;
using HostelManager.Services;
using HostelManager.Services.Interface;
using HosteManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//config AppSettings
var appConfig = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appConfig);
var appSettings = appConfig.Get<AppSettings>();

//dependancy injection add-on
builder.Services.AddTransient<IHostelServices, HostelServices>();
builder.Services.AddTransient<IGuestService, GuestService>();
builder.Services.AddTransient<IRoomsService, RoomService>();

builder.Services.AddTransient<IRepository<Hostel>,HostelRepository>();
builder.Services.AddTransient<IRepository<Room>, RoomsRepository>();
builder.Services.AddTransient<IRepository<Guest>, GuestRepository>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.
    AddDbContext<HostelManagerDbContex>(options => options.UseSqlServer("Server =.;Database=HostelManager_DB;Trusted_Connection = True;TrustServerCertificate=True"));
builder.Services.AddCors(options => options.AddPolicy("myPolicy", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//builder.Services.RegisterDataDependancies(appSettings.ConnectionString);
var app = builder.Build();
//Adding CORS


app.UseCors("myPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
