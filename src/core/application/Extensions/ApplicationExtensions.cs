using application.AppEntry;
using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using application.Features.user;
using Microsoft.Extensions.DependencyInjection;

namespace application.Extensions;

public static class ApplicationExtensions
{
    public static void RegisterCommandHandlers(this IServiceCollection services)
    {
        // TODO: Register command handlers here like this:
        // services.AddScoped<ICommandHandler<CreateWorkItemHandler>,CreateWorkItemHandler>();
        services.AddScoped<ICommandHandler<CreateUserCommand>, CreateUserHandler>();
        services.AddScoped<ICommandHandler<GetUserCommand>, GetUserHandler>();
        services.AddScoped<ICommandHandler<GetAllUsersCommand>, GetAllUsersHandler>();
        services.AddScoped<ICommandHandler<UpdateUserCommand>, UpdateUserHandler>();
        services.AddScoped<ICommandHandler<DeleteUserCommand>, DeleteUserHandler>();
    }


    public static void RegisterCommandDispatcher(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
    }
}