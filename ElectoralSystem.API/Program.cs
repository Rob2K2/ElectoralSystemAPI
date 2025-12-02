using ElectoralSystem.API.Core.DTOs;
using ElectoralSystem.API.Core.Handlers;
using ElectoralSystem.API.Core.Services;
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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqlContext>(
    options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("CleanCodeString")));

builder.Services.AddScoped<IPoliticalPartyRepository, PoliticalPartyRepository>();
builder.Services.AddScoped<IPollingStationRepository, PollingStationRepository>();
builder.Services.AddScoped<IPartyPollingResultRepository, PartyPollingResultRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<JwtService>();

builder.Services.AddScoped<ElectoralSystem.API.Error.Logs.ILogger, Logger>();

builder.Services.AddScoped<ErrorFilter>();
builder.Services.AddScoped<ValidatePoliticalPartyFilter>();
builder.Services.AddScoped<ValidatePollingStationFilter>();
builder.Services.AddScoped<ValidatePartyPollingResultFilter>();

builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssemblies(typeof(CreatePoliticalPartyMiddleData).Assembly)
);

builder.Services.AddAutoMapper(config =>
    {
        config.CreateMap<CreatePoliticalPartyDto, PoliticalParty>();
        config.CreateMap<UpdatePoliticalPartyDto, PoliticalParty>();
        config.CreateMap<PoliticalParty, PoliticalPartyResponseDto>();
        config.CreateMap<CreatePollingStationDto, PollingStation>();
        config.CreateMap<UpdatePollingStationDto, PollingStation>();
        config.CreateMap<PollingStation, PollingStationResponseDto>();
        config.CreateMap<CreatePartyPollingResultDto, PartyPollingResult>();
        config.CreateMap<UpdatePartyPollingResultDto, PartyPollingResult>();
        config.CreateMap<PartyPollingResult, PartyPollingResultResponseDto>();
        config.CreateMap<UserDto, User>();
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