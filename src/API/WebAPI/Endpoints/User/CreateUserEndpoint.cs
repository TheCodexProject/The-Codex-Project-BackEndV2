using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.user;

public class CreateUserEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRequest<CreateUserRequest>.WithResponse<CreateUserResponse>
{
    [HttpPost("/api/users")]
    public override async Task<ActionResult<CreateUserResponse>> HandleAsync(CreateUserRequest request)
    {
        // ! Validate the user's input
        // Before passing the request to the dispatcher, we need to validate the user's input.
        var cmd = CreateUserCommand.Create(request.FirstName, request.LastName, request.Email);

        // ? Were there any validation errors?
        if (cmd.IsFailure)
        {
            return BadRequest(cmd.Errors);
        }

        // * Dispatch the command
        var result = await dispatcher.DispatchAsync<CreateUserCommand>(cmd.Value);

        // ? Did the command fail?
        return result.IsFailure
            ? BadRequest(result.Errors) // ! Return the errors
            : Ok(new CreateUserResponse(cmd.Value.Uid.ToString())); // * Return Uid of the created user
    }
}

public record CreateUserRequest( [FromBody] string FirstName, [FromBody] string LastName, [FromBody] string Email);

public record CreateUserResponse(string Uid);