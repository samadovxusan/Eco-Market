using EcoMarket.Domaiin.Common.Queries;

namespace EcoMarket.Applicatioon.Clients.Queries;

public class CheckUserByEmailAddressQuery:IQuery<string>
{
    /// <summary>
    /// Gets user email address
    /// </summary>
    public string EmailAddress { get; set; } = default!;
}