using MediatR;

namespace EcoMarket.Domaiin.Common.Commands;

public interface ICommand<out TResult> : ICommand, IRequest<TResult>
{
    
}

/// <summary>
/// Defines interface for commands.
/// </summary>
public interface ICommand
{
    
}
