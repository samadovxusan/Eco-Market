using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Domaiin.Common.Queries;

namespace EcoMarket.Applicatioon.Clients.Queries;

public class ClientGetQuery:IQuery<ICollection<ClientDto>>
{
    public ClientFilter Filter { get; set; } = default!;
}