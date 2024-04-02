using MediatR;

namespace EcoMarket.Domaiin.Common.Queries;

public interface IQuery<out TResult> : IRequest<TResult>, IQuery
{
}

/// <summary>
/// Defines interface for queries in a CQRS architecture.
/// </summary>
public interface IQuery
{
}