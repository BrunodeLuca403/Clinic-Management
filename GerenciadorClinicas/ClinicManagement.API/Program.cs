using ClinicManagement.API.Middleware;
using ClinicManagement.Application;
using ClinicManagement.Application.Common;
using ClinicManagement.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfractructure(builder.Configuration);

builder.Services.AddApplication();


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMediator, Mediator>();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
