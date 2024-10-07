using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.Migrations;

public static class InfrastructureExtensions
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        // TODO: Register repositories here like this:
        // services.AddScoped<ICommandHandler<CreateWorkItemHandler>,CreateWorkItemHandler>();
    }
}