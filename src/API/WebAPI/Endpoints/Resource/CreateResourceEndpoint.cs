using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;
using application.AppEntry.Commands.resource;

namespace WebAPI.Endpoints.resource;
public class CreateResourceEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<CreateResourceRequest>.WithResponse<CreateResourceResponse>
{
    [HttpPost("resource/create")]
    public override async Task<ActionResult<CreateResourceResponse>> HandleAsync(CreateResourceRequest request)
    {
        Result<CreateResourceCommand> cmdResult = CreateResourceCommand.Create(title: request.Title, format: request.Format, refrence: request.Reference);
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
        CreateResourceResponse response = new CreateResourceResponse
        {
            Id = cmdResult.Value.Id.ToString(),
            Title = cmdResult.Value.title,
            Format = cmdResult.Value.format,
            Reference = cmdResult.Value.reference
        }; 

        return Ok(response);
    }
}

public record CreateResourceRequest
{
    [FromBody] public String? Title { get; init; }

    [FromBody] public String? Format { get; init; }

    [FromBody] public String? Reference { get; init; }
}

public record CreateResourceResponse
{
    public string? Id { get; init; }
    public String? Title { get; init; }

    public string? Format { get; init; }

    public string? Reference { get; init; }
}