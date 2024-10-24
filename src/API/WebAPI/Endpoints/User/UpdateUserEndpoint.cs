using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.user;

public class UpdateUserEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRouteAndRequest<UpdateUserRequest>.WithResponse<UpdateUserResponse>
{
    [HttpPatch("users/{uid}")]
    public override async Task<ActionResult<UpdateUserResponse>> HandleAsync(UpdateUserRequest request, [FromRoute] string uid)
    {
        // ! Validate the user's input
        // Before passing the request to the dispatcher, we need to validate the user's input.
        var cmd = UpdateUserCommand.Create(uid, request.FirstName, request.LastName, request.Email);

        // ? Were there any validation errors?
        if (cmd.IsFailure)
        {
            return BadRequest(cmd.Errors);
        }

        // * Dispatch the command
        var result = await dispatcher.DispatchAsync<UpdateUserCommand>(cmd.Value);

        // ? Did the command fail?
        return result.IsFailure
            ? BadRequest(result.Errors) // ! Return the errors
            : Ok(new UpdateUserResponse(cmd.Value.Uid.ToString(), cmd.Value.FirstName, cmd.Value.LastName, cmd.Value.Email)); // * Return the updated user
    }
}

public record UpdateUserRequest(string? FirstName, string? LastName, string? Email);

public record UpdateUserResponse(string Uid, string? FirstName, string? LastName, string? Email);