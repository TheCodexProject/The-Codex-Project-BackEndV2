using domain.models.resource;
using OperationResult;

namespace application.AppEntry.Commands.resource;

public class ReadAllResourcesCommand
{
    public IEnumerable<Resource>? Resources { get; set; }

    public ReadAllResourcesCommand()
    {

    }

    public static Result<ReadAllResourcesCommand> Create()
    {
        // Return a successful result with the created command
        return Result<ReadAllResourcesCommand>.Success(new ReadAllResourcesCommand());
    }
}
