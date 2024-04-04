using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Domaiin.Common.Commands;
using EcoMarket.Domain.Entities;

namespace EcoMarket.Applicatioon.Clients.Commands;

public record ClientUpdateCommand:ICommand<Client>
{
    public Guid Id { get; set; }
    /// <summary>
    /// Contains the updated organization data. 
    /// </summary>
    public ClientDto Client { get; init; } = default!;
}