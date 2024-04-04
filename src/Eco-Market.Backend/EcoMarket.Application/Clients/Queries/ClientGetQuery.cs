using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Domaiin.Common.Queries;
using EcoMarket.Domain.Entities;

namespace EcoMarket.Applicatioon.Clients.Queries;

public class ClientGetQuery:IQuery<ICollection<Client>>
{
    public ClientFilter Filter { get; set; } = default!;
}