using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;
using application.appEntry.commands.board;

namespace webAPI.endpoints.board;

public class CreateBoardEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<CreateBoardRequest>.WithResponse<CreateBoardResponse>
{
    [HttpPost("workspace/create")]
    public override async Task<ActionResult<CreateBoardResponse>> HandleAsync(CreateBoardRequest request)
    {
        Result<CreateBoardCommand> cmdResult = CreateBoardCommand.Create(title: request.Title);
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
        CreateBoardResponse response = new CreateBoardResponse
        {
            Id = cmdResult.Value.Id.ToString(),
            Title = cmdResult.Value.title,
        };

        return Ok(response);
    }
}

public record CreateBoardRequest
{
    [FromBody] public String? Title { get; init; }
}

public record CreateBoardResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }
}
