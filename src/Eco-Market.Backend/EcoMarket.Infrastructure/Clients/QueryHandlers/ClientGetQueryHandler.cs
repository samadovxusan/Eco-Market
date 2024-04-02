using AutoMapper;
using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Applicatioon.Clients.Queries;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Domaiin.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace EcoMarket.Infrastructuree.Clients.QueryHandlers;

public class ClientGetQueryHandler(IClientService service,IMapper mapper):IQueryHandler<ClientGetQuery,ICollection<ClientDto>>
{
    public async Task<ICollection<ClientDto>> Handle(ClientGetQuery request, CancellationToken cancellationToken)
    {
        var machedCliet = await service
            .Get(request.Filter, new QueryOptions() { TrackingMode = QueryTrackingMode.AsTracking })
            .ToListAsync(cancellationToken);
        return mapper.Map<ICollection<ClientDto>>(machedCliet);
    }
}