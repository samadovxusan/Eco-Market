using AutoMapper;
using EcoMarket.Applicatioon.Clients.Commands;
using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Domaiin.Common.Commands;
using EcoMarket.Domain.Entities;

namespace EcoMarket.Infrastructuree.Clients.CommandHandlers;

public class ClientUpdateCommandHandler(IClientService clientService,IMapper imapper) :ICommandHandler<ClientUpdateCommand,ClientDto>
{
    public async Task<ClientDto> Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
    {
        var client = imapper.Map<Client>(request.Client);
        var updateClient = await clientService.UpdateAsync(client, cancellationToken: cancellationToken);
        return imapper.Map<ClientDto>(updateClient);
    }
}