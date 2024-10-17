using application.appEntry.commands.board;
using application.AppEntry;
using application.AppEntry.Interfaces;
using application.features.board;
using Microsoft.Extensions.DependencyInjection;

namespace application.Extensions;

public static class ApplicationExtensions
{
    public static void RegisterCommandHandlers(this IServiceCollection services)
    {
        // TODO: Register command handlers here like this:
        // services.AddScoped<ICommandHandler<CreateWorkItemHandler>,CreateWorkItemHandler>();
        services.AddScoped<ICommandHandler<CreateBoardCommand>, CreateBoardHandler>();
        services.AddScoped<ICommandHandler<DeleteBoardCommand>, DeleteBoardHandler>();
        services.AddScoped<ICommandHandler<ReadAllBoardsCommand>, ReadAllBoardsHandler>();
        services.AddScoped<ICommandHandler<ReadBoardCommand>, ReadBoardHandler>();
        services.AddScoped<ICommandHandler<UpdateBoardCommand>, UpdateBoardHandler>();
    }


    public static void RegisterCommandDispatcher(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
    }
}