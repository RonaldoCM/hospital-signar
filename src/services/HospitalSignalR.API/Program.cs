using HospitalSignalR.API.Mappings;
using HospitalSignalR.Core.Abstractions.Repositories;
using HospitalSignalR.Core.Abstractions.Services;
using HospitalSignalR.Core.Services;
using HospitalSignalR.Infraestructure.Data;
using HospitalSignalR.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy((policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    }));
});

#region IoC

builder.Services.AddDbContext<HospitalSignalRContextDb>(opt =>
{
    opt.UseInMemoryDatabase("HospitalSignalR");
});

builder.Services.AddScoped<ITriageService, TriageService>();
builder.Services.AddScoped<ITriageRepository, TriageRepository>();
builder.Services.AddScoped<IMedicalCareService, MedicalCareService>();
builder.Services.AddScoped<IMedicalCareRepository, MedicalCareRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapGroup("api").MapRoutes();
app.MapHubs();

app.Run();