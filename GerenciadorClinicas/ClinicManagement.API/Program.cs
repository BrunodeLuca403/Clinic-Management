using ClinicManagement.API.Context;
using ClinicManagement.Core.Repository;
using ClinicManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ClinicConnection");

builder.Services.AddDbContext<ClinicDbContext>(e => e.UseSqlServer(connectionString));

builder.Services.AddScoped<ClinicDbContext, ClinicDbContext>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IMedicRepository, MedicRepository>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<ICareRepository, CareRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    //app.UseSwagger();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicManagement API V1");
    //    c.RoutePrefix = string.Empty; // abre direto em http://localhost:5000/
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
