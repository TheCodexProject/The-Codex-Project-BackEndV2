using application.appEntry.commands.board;
using application.AppEntry.Commands.Board;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace webAPI.endpoints.board;

public class ReadAllBoardEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<ReadAllBoardRequest>.WithResponse<ReadAllBoardResponse>
{
    [HttpPost("workspace")]
    public override async Task<ActionResult<ReadAllBoardResponse>> HandleAsync(ReadAllBoardRequest request)
    {
        // Create the command
        Result<ReadAllBoardsCommand> cmdResult = ReadAllBoardsCommand.Create();
        if (cmdResult.IsFailure)
        {
            return BadRequest(cmdResult.Errors);
        }

        // Dispatch the command
        Result result = await dispatcher.DispatchAsync(cmdResult.Value);

        if (result.IsFailure)
        {
            return BadRequest(result.Errors);
        }

        // Convert Boards to BoardResponses
        List<BoardResponse> boardResponses = cmdResult.Value.Boards.Select(board => new BoardResponse
        {
            Id = board.Id.ToString(),
            Title = board.Title
        }).ToList();

        // Create the response object
        ReadAllBoardResponse response = new ReadAllBoardResponse
        {
            boards = boardResponses,
        };

        return Ok(response);
    }
}

public record ReadAllBoardRequest
{
    [FromRoute] public required string Id { get; set; }
    [FromBody] public String? Title { get; init; }
}

public record ReadAllBoardResponse
{
    public List<BoardResponse>? boards { get; set; }
}

public record BoardResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }
}
