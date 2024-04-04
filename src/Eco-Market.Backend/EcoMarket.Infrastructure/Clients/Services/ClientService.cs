using System.Linq.Expressions;
using EcoMarket.Applicatioon.Clients.Models;
using EcoMarket.Domaiin.Common.Commands;
using EcoMarket.Domaiin.Common.Queries;
using EcoMarket.Domain.Entities;
using EcoMarket.Domain.Enums;
using EcoMarket.Persistencee.Extentions;
using EcoMarket.Persistencee.Repositories.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace EcoMarket.Applicatioon.Clients.Services;

public class ClientService(IClientRepository clientRepository,IValidator<Client> clientValidator):IClientService
{
    public IQueryable<Client> Get(Expression<Func<Client, bool>>? predicate = default,QueryOptions queryOptions = default)
        => clientRepository.Get(predicate,queryOptions);

    public IQueryable<Client> Get(ClientFilter clientFilter, QueryOptions queryOptions = default)
        => clientRepository.Get(queryOptions: queryOptions).ApplyPagination(clientFilter);
    
    
    public ValueTask<Client?> GetByIdAsync(Guid clientId,QueryOptions queryOptions = default, CancellationToken cancellationToken = default)
        => clientRepository.GetByIdAsync(clientId,queryOptions,cancellationToken);

    public ValueTask<Client> CreateAsync(Client client, CommandOptions commandOptions = default,
                                         CancellationToken cancellationToken = default)
    {
        var validationresult = clientValidator
            .Validate(client,
                options =>
                    options.IncludeRuleSets(EntityEvent.OnCreate.ToString()));
        if (!validationresult.IsValid)
        {
            throw new ValidationException(validationresult.Errors);
        }
        client.CreatedTime = DateTime.UtcNow;
        return clientRepository.CreateAsync(client,new CommandOptions() {SkipSaveChanges = false},cancellationToken);
    }

    public async ValueTask<Client?> UpdateAsync(Guid clientid,Client client, CommandOptions commandOptions = default,
                                          CancellationToken cancellationToken = default)
    {
        var found = await GetByIdAsync(clientid, cancellationToken: cancellationToken) ??
                    throw new InvalidOperationException();
        found.FirstName = client.FirstName;
        found.LastName = client.LastName;
        found.ModifiedTime = DateTime.UtcNow;
        return await clientRepository.UpdateAsync(found, commandOptions, cancellationToken);
    }
    public ValueTask<Client?> DeleteByIdAsync(Guid clientId,CommandOptions commandOptions = default, CancellationToken cancellationToken = default)
        => clientRepository.DeleteByIdAsync(clientId,commandOptions,cancellationToken);

}