using EcoMarket.Domaiin.Common.Commands;

namespace EcoMarket.Applicatioon.Clients.Commands;

public record ClientDeleteByIdCommand:ICommand<bool>
{
    /// <summary>
    /// Gets the unique identifier of the client to delete.
    /// </summary>
    public Guid ClientId { get; init; }
}