using EcoMarket.Applicatioon.Clients.Commands;
using EcoMarket.Applicatioon.Clients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace EcoMarket.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class ClientController(IMediator mediator ) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] ClientGetQuery clientGetQuery,
                                              CancellationToken cancellationToken)
    {
        var result = await mediator.Send(clientGetQuery, cancellationToken);
        return Ok(result);
    }
    [HttpGet("{clientId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid clientid,
                                              CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new ClientByIdQuery{Id = clientid}, cancellationToken);
        return result is not null ? Ok(result) : NoContent();
    }
    [HttpGet("by-email/{emailAddress}")]
    public async ValueTask<IActionResult> CheckClientByEmail([FromRoute] string emailAddress, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CheckUserByEmailAddressQuery { EmailAddress = emailAddress }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }
    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] ClientUpdateCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{clientId:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid clientId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new ClientDeleteByIdCommand {ClientId = clientId}, cancellationToken);
        return result ? Ok() : BadRequest();
    }
    
    
    
    
    
    
}
