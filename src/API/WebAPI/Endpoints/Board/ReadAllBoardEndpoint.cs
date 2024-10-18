using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace webAPI.endpoints.board;

public class ReadAllBoardEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithoutRequest.WithResponse<ReadAllBoardResponse>
{
    [HttpPost("workspace/readAll")]
    public override async Task<ActionResult<ReadAllBoardResponse>> HandleAsync()
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
            Id = board.Uid.ToString(),
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

public record ReadAllBoardResponse
{
    public List<BoardResponse>? boards { get; set; }
}

public record BoardResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }
}
