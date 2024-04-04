using EcoMarket.Domain.Entities;
using EcoMarket.Domain.Enums;
using EcoMarket.Persistencee.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EcoMarket.Api.Data;

public static class SeedDataExtentions
{
    public static async ValueTask InitializeSeedAsync(this IServiceProvider serviceProvider)
    {
        var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();

        if (!await appDbContext.Clients.AnyAsync())
            await appDbContext.SeedClientsAsync();
    }



    private static async ValueTask SeedClientsAsync(this AppDbContext dbContext)
    {
        var clients = new List<Client>
        {
            new()
            {
                Id = Guid.Parse("54e16310-d140-4453-80c9-1a117dbe75fd"),
                FirstName = "John",
                LastName = "Doe",
                Role = Role.Guest
                
            },
            new()
            {
            Id = Guid.Parse("54e16318-d120-4453-80c9-1a117dbe75fd"),
            FirstName = "husan",
            LastName = "Doe",
            Role = Role.Admin
            },
            new()
            {
                Id = Guid.Parse("54e16618-d140-4453-80c9-1a117dbe75fd"),
                FirstName = "odil",
                LastName = "Doe",
                Role = Role.System
            }
        };
        await dbContext.Clients.AddRangeAsync(clients);
        await dbContext.SaveChangesAsync();
    }
}