using application.AppEntry.Commands.resource;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.resource;

public class DeleteResourceEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<DeleteResourceRequest>.WithoutResponse
{
    [HttpPost("workspace/{id}/delete")]
    public override async Task<ActionResult> HandleAsync(DeleteResourceRequest request)
    {
        Result<DeleteResourceCommand> cmdResult = DeleteResourceCommand.Create(id: request.Id);
        if (cmdResult.IsFailure)
        {
            return BadRequest(cmdResult.Errors);
        }

        Result result = await dispatcher.DispatchAsync(cmdResult.Value);

        if (result.IsFailure)
        {
            return BadRequest(result.Errors);
        }

        return Ok();
    }
}

public record DeleteResourceRequest
{
    [FromRoute] public required string Id { get; set; }
}