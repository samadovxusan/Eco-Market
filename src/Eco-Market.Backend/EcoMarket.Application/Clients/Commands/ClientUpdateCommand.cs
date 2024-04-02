using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Domaiin.Common.Commands;

namespace EcoMarket.Applicatioon.Clients.Commands;

public record ClientUpdateCommand:ICommand<ClientDto>
{
    
    /// <summary>
    /// Contains the updated organization data. 
    /// </summary>
    public ClientDto Client { get; init; } = default!;
}