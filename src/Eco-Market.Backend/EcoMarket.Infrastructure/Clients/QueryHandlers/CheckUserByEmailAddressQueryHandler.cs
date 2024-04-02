using EcoMarket.Applicatioon.Clients.Queries;
using EcoMarket.Applicatioon.Clients.Services;
using EcoMarket.Domaiin.Common.Queries;
using EcoMarket.Persistencee.Extentions;

namespace EcoMarket.Infrastructuree.Clients.QueryHandlers;

public class CheckUserByEmailAddressQueryHandler(IClientService service):
    IQueryHandler<CheckUserByEmailAddressQuery,string>
{
    public Task<string> Handle(CheckUserByEmailAddressQuery request, CancellationToken cancellationToken)
    {
        var clientFirstname = service
            .Get(
                client => client.FirstName == request.EmailAddress,
                new QueryOptions
                {
                    TrackingMode = QueryTrackingMode.AsTracking
                }
            )
            .Select(client => client.FirstName)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        return clientFirstname;
    }
}