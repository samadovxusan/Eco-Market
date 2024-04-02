namespace EcoMarket.Api.Configurations;
public static partial class HostConfiguration
{
    /// <summary>
    /// Configures application builder
    /// </summary>
    /// <param name="builder">Application builder</param>
    /// <returns>Application builder</returns>
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddMappers()
            .AddValidators()
            .AddPersistence()
            .AddMediator()
            .AddDevTools()
            .AddClientInfrastructure()   
            .AddExposers();
            
            
        return new(builder);
    }

    /// <summary>
    /// Configures application
    /// </summary>
    /// <param name="app">Application host</param>
    /// <returns>Application host</returns>
    public static  ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevtools()
            .UseExposers();
        return new ValueTask<WebApplication>(app);
    }
}