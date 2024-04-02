using EcoMarket.Domain.Common.Entities;
using EcoMarket.Domain.Enums;

namespace EcoMarket.Domain.Entities;

public class Client: AuditableEntity
{
    /// <summary>
    /// Gets or sets the first name of the client.
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the last name of the client.
    /// </summary>
    public string LastName { get; set; } = default!;
    /// <summary>
    /// Gets or sets the role of the client.
    /// </summary>
    public Role Role { get; set; }
}