using ClinicManagement.API.Context;
using ClinicManagement.API.Middleware;
using ClinicManagement.Application.Commands.Care.CreateCare;
using ClinicManagement.Application.Commands.Care.DeleteCare;
using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.ViewModel.Care;
using ClinicManagement.Application.Query.Care.DetailsCare;
using ClinicManagement.Application.Query.Care.ListCare;
using ClinicManagement.Core.Repository;
using ClinicManagement.Infrastructure.Caching;
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
builder.Services.AddScoped<IHandler<CreateCareCommand, ResultViewModel<Guid>>, CreateCareCommandHadler>();
builder.Services.AddScoped<IHandler<ListCareQuery, ResultViewModel<List<ListCareDto>>>, LIstCareQueryHandler>();
builder.Services.AddScoped<IHandler<DeleteCareCommand, ResultViewModel<Guid>>, DeleteCareCommandHandler>();
builder.Services.AddScoped<IHandler<DetailsCareQuery, ResultViewModel<DetailsCareDto>>, DetailsCareQueryHandler>();

builder.Services.AddScoped<ICachingService, CachingService>();
builder.Services.AddStackExchangeRedisCache(o =>
{
    o.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    o.InstanceName = "localhost:6379";
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMediator, Mediator>();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
        // possivelmente definir rota base
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
