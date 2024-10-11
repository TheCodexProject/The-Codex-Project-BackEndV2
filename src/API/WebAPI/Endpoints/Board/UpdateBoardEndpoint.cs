﻿

using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace webAPI.endpoints.board;

public class UpdateBoardEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<UpdateBoardRequest>.WithResponse<Result>
{
    [HttpPost("workspace/{id}")]
    public override async Task<ActionResult<Result>> HandleAsync(UpdateBoardRequest request)
    {
        Result<UpdateBoardCommand> cmdResult = UpdateBoardCommand.Create(Id: request.Id, Title: request.Title);
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
            Id = cmdResult.Value.id,
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
}