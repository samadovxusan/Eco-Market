using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Domaiin.Common.Commands;
using EcoMarket.Domain.Entities;
using EcoMarket.Domain.Enums;

namespace EcoMarket.Applicatioon.Clients.Commands;

public record ClientCreateCommand:ICommand<Client>
{
   public ClientDto CreateClient { get; set; }
}