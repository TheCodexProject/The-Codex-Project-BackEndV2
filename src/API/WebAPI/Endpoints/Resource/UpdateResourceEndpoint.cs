using application.AppEntry.Commands.resource;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.Resource;

public class UpdateResourceEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<UpdateResourceRequest>.WithResponse<UpdateResourceResponse>
{
    [HttpPost("resource/{id}/update")]
    public override async Task<ActionResult<UpdateResourceResponse>> HandleAsync(UpdateResourceRequest request)
    {
        Result<UpdateResourceCommand> cmdResult = UpdateResourceCommand.Create(id: request.Id, title: request.Title, format: request.Format, reference: request.Reference);
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
        UpdateResourceResponse response = new UpdateResourceResponse
        {
            Id = cmdResult.Value.Id.ToString(),
            Title = cmdResult.Value.Title,
            Format = cmdResult.Value.Format,
            Reference = cmdResult.Value.Reference
        };

        return Ok(response);
    }
}

public record UpdateResourceRequest
{
    [FromRoute] public required string Id { get; set; }
    [FromBody] public String? Title { get; init; }

    [FromBody] public String? Format { get; init; }

    [FromBody] public String? Reference { get; init; }
}

public record UpdateResourceResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }

    public String? Format { get; init; }

    public String? Reference { get; init; }
}