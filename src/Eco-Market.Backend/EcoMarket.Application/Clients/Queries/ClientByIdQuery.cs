using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Domaiin.Common.Queries;
using EcoMarket.Domain.Entities;

namespace EcoMarket.Applicatioon.Clients.Queries;

public class ClientByIdQuery:IQuery<ClientDto>
{
    public Guid Id { get; set; }
    
}