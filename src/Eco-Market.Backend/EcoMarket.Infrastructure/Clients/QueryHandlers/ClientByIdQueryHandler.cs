using AutoMapper;
using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Applicatioon.Clients.Queries;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Domaiin.Common.Queries;

namespace EcoMarket.Infrastructuree.Clients.QueryHandlers;

public class ClientByIdQueryHandler(IClientService service, IMapper mapper):IQueryHandler<ClientByIdQuery,ClientDto>
{
    public async Task<ClientDto> Handle(ClientByIdQuery request, CancellationToken cancellationToken)
    {
        var foundClient = await service.GetByIdAsync(
            request.Id,
            new QueryOptions()
            {
                TrackingMode = QueryTrackingMode.AsTracking
            },
            cancellationToken
        );
        return mapper.Map<ClientDto>(foundClient);
    }
}