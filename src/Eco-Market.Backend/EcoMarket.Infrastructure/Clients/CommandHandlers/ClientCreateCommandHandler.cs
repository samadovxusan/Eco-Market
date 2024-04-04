using AutoMapper;
using EcoMarket.Applicatioon.Clients.Commands;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Domaiin.Common.Commands;
using EcoMarket.Domaiin.Common.Queries;
using EcoMarket.Domain.Entities;

namespace EcoMarket.Infrastructuree.Clients.CommandHandlers;

public class ClientCreateCommandHandler(IClientService clientService ,IMapper mapper):ICommandHandler<ClientCreateCommand,Client>
{
    public async Task<Client> Handle(ClientCreateCommand request, CancellationToken cancellationToken)
    {
        var Client = mapper.Map<Client>(request.CreateClient);
        var CreateClient = await clientService.CreateAsync(Client, cancellationToken: cancellationToken);
        return mapper.Map<Client>(CreateClient);

    }
}