
using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace webAPI.endpoints.board;

public class DeleteBoardEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<DeleteBoardRequest>.WithoutResponse
{
    [HttpPost("workspace/{id}/delete")]
    public override async Task<ActionResult> HandleAsync(DeleteBoardRequest request)
    {
        Result<DeleteBoardCommand> cmdResult = DeleteBoardCommand.Create(id: request.Id);
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

public record DeleteBoardRequest
{
    [FromRoute] public required string Id { get; set; }
}