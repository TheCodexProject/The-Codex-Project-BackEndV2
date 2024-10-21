using OperationResult;

namespace application.AppEntry.Commands.resource;

public class ReadResourceCommand
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Format {  get; set; }

    public string Reference { get; set; }

    public ReadResourceCommand(Guid id)
    {
        this.Id = id;
    }

    public static Result<ReadResourceCommand> Create(string id)
    {
        // Validate that the input is a valid GUID
        if (!Guid.TryParse(id, out Guid parsedId))
        {
            return Result<ReadResourceCommand>.Failure(new Exception("Invalid GUID format for Id."));
        }

        // Return a successful result with the created command
        return Result<ReadResourceCommand>.Success(new ReadResourceCommand(parsedId));
    }
}