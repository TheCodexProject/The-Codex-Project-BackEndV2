using domain.models.user;

namespace application.AppEntry.Commands.user;

public class GetAllUsersCommand
{
    public List<User> Users { get; set; } = [];

    public static GetAllUsersCommand Create()
    {
        return new GetAllUsersCommand();
    }
}