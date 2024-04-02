using System.Linq.Expressions;
using EcoMarket.Domaiin.Common.Commands;
using EcoMarket.Domaiin.Common.Queries;
using EcoMarket.Domain.Entities;
using EcoMarket.Persistencee.DataContext;
using EcoMarket.Persistencee.Repositories.Interfaces;

namespace EcoMarket.Persistencee.Repositories;

public class ClientRepository(AppDbContext appDbContext ):EntityRepositoryBase<Client,AppDbContext>(appDbContext),IClientRepository
{
    public IQueryable<Client> Get(Expression<Func<Client, bool>>? predicate = default, QueryOptions queryOptions = default) 
        => base.Get(predicate,queryOptions);

    public ValueTask<Client?> GetByIdAsync(Guid clientId, QueryOptions queryOptions = default, CancellationToken cancellationToken = default)
        => base.GetByIdAsync(clientId,queryOptions, cancellationToken);

    public ValueTask<Client> CreateAsync(Client client,CommandOptions commandOptions = default, CancellationToken cancellationToken = default) 
        => base.CreateAsync(client, commandOptions,cancellationToken);

    public ValueTask<Client> UpdateAsync(Client client, CommandOptions commandOptions = default, CancellationToken cancellationToken = default) 
        => base.UpdateAsync(client,commandOptions, cancellationToken);

    public ValueTask<Client?> DeleteByIdAsync(Guid clientId,CommandOptions commandOptions = default, CancellationToken cancellationToken = default) 
        => base.DeleteByIdAsync(clientId,commandOptions, cancellationToken);
}