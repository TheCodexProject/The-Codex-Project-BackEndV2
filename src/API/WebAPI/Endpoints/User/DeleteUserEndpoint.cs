using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.user;

public class DeleteUserEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRoute.WithoutResponse
{
    [HttpDelete("users/{uid}")]
    public override async Task<ActionResult> HandleAsync(string uid)
    {
        // ! Validate the user's input
        var cmd = DeleteUserCommand.Create(uid);

        // ? Were there any validation errors?
        if (cmd.IsFailure)
        {
            return BadRequest(cmd.Errors);
        }

        // * Dispatch the command
        var result = await dispatcher.DispatchAsync<DeleteUserCommand>(cmd.Value);

        // ? Did the command fail?
        return result.IsFailure
            ? BadRequest(result.Errors) // ! Return the errors
            : Ok("User was successfully deleted."); // * Return the user
    }
}