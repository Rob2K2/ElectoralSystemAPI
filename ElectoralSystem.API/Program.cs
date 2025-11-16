using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Error.Logs;
using ElectoralSystem.API.Filter;
using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using ElectoralSystem.API.Repository.Interfaces;
using ElectoralSystem.API.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    options => options.Filters.Add<ErrorFilter>()    
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqlContext>(
    options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("CleanCodeString")));

builder.Services.AddScoped<IPoliticalPartyRepository, PoliticalPartyRepository>();

builder.Services.AddScoped<ElectoralSystem.API.Error.Logs.ILogger, Logger>();

builder.Services.AddScoped<ErrorFilter>();
builder.Services.AddScoped<ValidatePoliticalPartyFilter>();

builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssemblies(typeof(CreatePoliticalPartyMiddleData).Assembly)
);

builder.Services.AddAutoMapper(config =>
    {
        config.CreateMap<PoliticalParty, PoliticalPartyDto>();
        config.CreateMap<PoliticalPartyDto, PoliticalParty>();
    }
);

builder.Logging.AddLog4Net("LogConfig.config");

var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{
    var context = scope.ServiceProvider.GetRequiredService<SqlContext>();
    context.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();


app.Run();