using EcoMarket.Applicatioon.Clients.Commands;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Domaiin.Common.Commands;

namespace EcoMarket.Infrastructuree.Clients.CommandHandlers;

public class ClientDeleteByIDCommandHandler(IClientService clientService):ICommandHandler<ClientDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(ClientDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        await clientService.DeleteByIdAsync(request.ClientId, cancellationToken: cancellationToken);
        return true;
    }
}