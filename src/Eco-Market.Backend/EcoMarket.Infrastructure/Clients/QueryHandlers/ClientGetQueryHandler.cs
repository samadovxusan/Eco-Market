using AutoMapper;
using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Applicatioon.Clients.Queries;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Domaiin.Common.Queries;
using EcoMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoMarket.Infrastructuree.Clients.QueryHandlers;

public class ClientGetQueryHandler(IClientService service,IMapper mapper):IQueryHandler<ClientGetQuery,ICollection<Client>>
{
    public async Task<ICollection<Client>> Handle(ClientGetQuery request, CancellationToken cancellationToken)
    {
        var machedCliet = await service
            .Get(request.Filter, new QueryOptions() { TrackingMode = QueryTrackingMode.AsTracking })
            .ToListAsync(cancellationToken);
        return mapper.Map<ICollection<Client>>(machedCliet);
    }
}