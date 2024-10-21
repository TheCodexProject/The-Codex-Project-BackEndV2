using application.AppEntry.Commands.resource;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.Resource;

public class ReadResourceEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<ReadResourceRequest>.WithResponse<ReadResourceResponse>
{
    [HttpPost("resource/{id}/read")]
    public override async Task<ActionResult<ReadResourceResponse>> HandleAsync(ReadResourceRequest request)
    {
        Result<ReadResourceCommand> cmdResult = ReadResourceCommand.Create(id: request.Id);
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
        ReadResourceResponse response = new ReadResourceResponse
        {
            Id = cmdResult.Value.Id.ToString(),
            Title = cmdResult.Value.Title,
            Format = cmdResult.Value.Format,
            Reference = cmdResult.Value.Reference,
        };

        return Ok(response);
    }
}

public record ReadResourceRequest
{
    [FromRoute] public required string Id { get; set; }
}

// TODO make this return a board obj
public record ReadResourceResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }

    public String? Format { get; init; }

    public String? Reference { get; init; }
}