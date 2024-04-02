using System.Reflection;
using System.Text;
using EcoMarket.Applicatioon.Clients.Mappers;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Applicatioon.Common.Settings;
using EcoMarket.Persistencee.DataContext;
using EcoMarket.Persistencee.Repositories;
using EcoMarket.Persistencee.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace EcoMarket.Api.Configurations;

public static partial class  HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;
    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var dbConnectionString = builder.Environment.IsProduction()
            ? Environment.GetEnvironmentVariable("DefaultConnectionString")
            : builder.Configuration.GetConnectionString("DefaultConnectionString");
        
        // Register db context
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(dbConnectionString);
        });
        return builder;
    }
    private static WebApplicationBuilder AddClientInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        

        return builder;
    }
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();
        
        return builder;
    }
    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);
        return builder;
    }
    
   
    
    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ValidationSettings>(builder.Configuration.GetSection(nameof(ValidationSettings)));

        builder.Services.AddValidatorsFromAssemblies(Assemblies).AddFluentValidationAutoValidation();
        
        return builder;
    }
    private static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(conf => {conf.RegisterServicesFromAssemblies(Assemblies.ToArray());});
        
        return builder;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        
        return app;
    }
    private static WebApplication UseDevtools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }
}