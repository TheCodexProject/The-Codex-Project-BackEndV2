using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using domain.exceptions.common;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using WebAPI.Endpoints.Common;

namespace WebAPI.Endpoints.user;

public class GetUserEndpoint(ICommandDispatcher dispatcher) : ApiEndpoint.WithRoute.WithResponse<GetUserResponse>
{

    [HttpGet("/api/users/{uid}")]
    public override async Task<ActionResult<GetUserResponse>> HandleAsync([FromRoute] string uid)
    {
        // ! Validate the user's input
        var cmd = GetUserCommand.Create(uid);

        // ? Were there any validation errors?
        if (cmd.IsFailure)
        {
            return BadRequest(cmd.Errors);
        }

        // * Dispatch the command
        var result = await dispatcher.DispatchAsync<GetUserCommand>(cmd.Value);

        // ? Did the command fail?
        return result.IsFailure
            ? BadRequest(result.Errors) // ! Return the errors
            : Ok(new GetUserResponse(cmd.Value.Uid.ToString(), cmd.Value.FirstName, cmd.Value.LastName, cmd.Value.Email)); // * Return the user
    }
}

public record GetUserResponse(string Uid, string FirstName, string LastName, string Email);