using application.AppEntry.Commands.resource;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.resource;

public class ReadAllResourceEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithoutRequest.WithResponse<ReadAllResourceResponse>
{
    [HttpPost("resource/readAll")]
    public override async Task<ActionResult<ReadAllResourceResponse>> HandleAsync()
    {
        // Create the command
        Result<ReadAllResourcesCommand> cmdResult = ReadAllResourcesCommand.Create();
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
        List<ResourceResponse> boardResponses = cmdResult.Value.Resources.Select(board => new ResourceResponse
        {
            Id = board.Uid.ToString(),
            Title = board.Title
        }).ToList();

        // Create the response object
        ReadAllResourceResponse response = new ReadAllResourceResponse
        {
            resources = boardResponses,
        };

        return Ok(response);
    }
}

public record ReadAllResourceResponse
{
    public List<ResourceResponse>? resources { get; set; }
}

public record ResourceResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }

    public String? Format { get; init; }

    public String? Reference { get; init; }
}