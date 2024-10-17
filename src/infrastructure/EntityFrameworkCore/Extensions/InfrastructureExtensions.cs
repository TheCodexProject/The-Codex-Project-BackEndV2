using domain.interfaces;
using domain.models.board;
using domain.models.iteration;
using domain.models.milestone;
using domain.models.organization;
using domain.models.project;
using domain.models.resource;
using domain.models.user;
using domain.models.workitem;
using domain.models.workspace;
using EntityFrameworkCore.repositories.models;
using EntityFrameworkCore.tools;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.extensions;

public static class InfrastructureExtensions
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        // TODO: Register Repositories here like this:
        services.AddScoped<IRepository<Workspace>, WorkspaceRepository>();
        services.AddScoped<IRepository<WorkItem>, WorkItemRepository>();
        services.AddScoped<IRepository<User>, UserRepository>();
        services.AddScoped<IRepository<Resource>, ResourceRepository>();
        services.AddScoped<IRepository<Project>, ProjectRepository>();
        services.AddScoped<IRepository<Organization>, OrganizationRepository>();
        services.AddScoped<IRepository<Milestone>, MilestoneRepository>();
        services.AddScoped<IRepository<Iteration>, IterationRepository>();
        services.AddScoped<IRepository<Board>, BoardRepository>();
    }

    public static void RegisterUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}