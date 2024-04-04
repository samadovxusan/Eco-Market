using AutoMapper;
using EcoMarket.Applicatioon.Clients.Commands;
using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Domaiin.Common.Commands;
using EcoMarket.Domain.Entities;
using EcoMarket.Persistencee.Migrations;

namespace EcoMarket.Infrastructuree.Clients.CommandHandlers;

public class ClientUpdateCommandHandler(IClientService clientService,IMapper imapper) :ICommandHandler<ClientUpdateCommand,Client>
{
    public async Task<Client> Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
    {
        var client = imapper.Map<Client>(request.Client);
        var updateClient = await clientService.UpdateAsync(request.Id, client, cancellationToken: cancellationToken);
        return imapper.Map<Client>(updateClient);
    }
}