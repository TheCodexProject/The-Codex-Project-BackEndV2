using OperationResult;

namespace application.AppEntry.Commands.resource;

public class DeleteResourceCommand
{
    public Guid Id { get; set; }

    public DeleteResourceCommand(Guid id)
    {
        this.Id = id;
    }

    public static Result<DeleteResourceCommand> Create(string id)
    {
        // Validate that the input is a valid GUID
        if (!Guid.TryParse(id, out Guid parsedId))
        {
            return Result<DeleteResourceCommand>.Failure(new Exception("Invalid GUID format for Id."));
        }

        // Return a successful result with the created command
        return Result<DeleteResourceCommand>.Success(new DeleteResourceCommand(parsedId));
    }
}