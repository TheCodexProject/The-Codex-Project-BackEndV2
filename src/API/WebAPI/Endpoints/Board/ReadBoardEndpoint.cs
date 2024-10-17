
using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace webAPI.endpoints.board;

public class ReadBoardEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<ReadBoardRequest>.WithResponse<ReadBoardResponse>
{
    [HttpPost("workspace/{id}")]
    public override async Task<ActionResult<ReadBoardResponse>> HandleAsync(ReadBoardRequest request)
    {
        Result<ReadBoardCommand> cmdResult = ReadBoardCommand.Create(id: request.Id);
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
        ReadBoardResponse response = new ReadBoardResponse
        {
            Id = "" + cmdResult.Value.Id,
            Title = cmdResult.Value.Title,
        };

        return Ok(response);
    }
}

public record ReadBoardRequest
{
    [FromRoute] public required string Id { get; set; }
    [FromBody] public String? Title { get; init; }
}

// TODO make this return a board obj
public record ReadBoardResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }
}
