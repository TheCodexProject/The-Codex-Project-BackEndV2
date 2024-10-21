using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using domain.models.user;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.user;

public class GetAllUsersEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithoutRequest.WithResponse<GetUsersResponse>
{
    [HttpGet("api/users")]
    public override async Task<ActionResult<GetUsersResponse>> HandleAsync()
    {
        // * Create the command.
        var cmd = GetAllUsersCommand.Create();

        // * Dispatch the command.
        var result = await dispatcher.DispatchAsync<GetAllUsersCommand>(cmd);

        // ? Did the command fail?
        return result.IsFailure
            ? BadRequest(result.Errors) // ! Return the errors
            : Ok(new GetUsersResponse(cmd.Users)); // * Return the users
    }
}

public record GetUsersResponse(List<User> Users);