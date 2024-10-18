

using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace webAPI.endpoints.board;

public class UpdateBoardEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<UpdateBoardRequest>.WithResponse<UpdateBoardResponse>
{
    [HttpPost("workspace/{id}/update")]
    public override async Task<ActionResult<UpdateBoardResponse>> HandleAsync(UpdateBoardRequest request)
    {
        Result<UpdateBoardCommand> cmdResult = UpdateBoardCommand.Create(id: request.Id, title: request.Title);
        if (cmdResult.IsFailure)
        {
            return BadRequest(cmdResult.Errors);
        }

        Result result = await dispatcher.DispatchAsync(cmdResult.Value);

        if (result.IsFailure)
        {
            return BadRequest(result.Errors);
        }

        // You need to create the response object here
        UpdateBoardResponse response = new UpdateBoardResponse
        {
            Id = ""+cmdResult.Value.Id,
            Title = cmdResult.Value.Title,
        };

        return Ok(response);
    }
}

public record UpdateBoardRequest
{
    [FromRoute] public required string Id { get; set; }
    [FromBody] public String? Title { get; init; }
}

public record UpdateBoardResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }
}