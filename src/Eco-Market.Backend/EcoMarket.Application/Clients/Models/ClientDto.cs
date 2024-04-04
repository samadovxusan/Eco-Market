using EcoMarket.Domain.Enums;

namespace EcoMarket.Applicatioon.Clients.Models;

public class ClientDto
{
    /// <summary>
    /// Gets or sets the first name of the client.
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the last name of the client.
    /// </summary>
    public string LastName { get; set; } = default!;
    
    public Role Role { get; set; } = default!;
}