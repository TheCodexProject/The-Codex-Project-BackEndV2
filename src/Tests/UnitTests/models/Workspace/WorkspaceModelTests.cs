using domain.exceptions.models.workspace;
using domain.models.project;
using domain.models.resource;
using domain.models.user;
using domain.models.workspace;
using domain.models.workspace.values;

namespace UnitTests.models.workspace;

public class WorkspaceModelTests
{
    // #1 - Workspace can be created
    [Fact]
    public void Workspace_can_be_created()
    {
        // Arrange
        var workspace = Workspace.Create();

        // Act

        // Assert
        Assert.NotNull(workspace);
    }

    // #2 - Title updates using the UpdateTitle method
    [Theory]
    [InlineData("The Art of Coding")]
    [InlineData("Exploring Machine Learning")]
    [InlineData("Effective Team Communication")]
    [InlineData("Cybersecurity Essentials")]
    [InlineData("Mastering Data Structures")]
    public void Workspace_can_update_title_success(string title)
    {
        // Arrange
        var workspace = Workspace.Create();

        // Act
        workspace.UpdateTitle(title);

        // Assert
        Assert.True(workspace.Title == title);
    }

    // #2A - Title can not be null or empty
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Workspaces_Title_cannot_be_null_or_empty(string title)
    {
        // Arrange
        var workspace = Workspace.Create();

        // Act
        var result = workspace.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is WorkspaceTitleEmptyException);
    }

    // #2B - Title has to be at least 3 characters long
    [Theory]
    [InlineData("AI")]
    [InlineData("ML")]
    [InlineData("C#")]
    public void Workspace_can_update_title_fail(string title)
    {
        // Arrange
        var workspace = Workspace.Create();

        // Act
        var result = workspace.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is WorkspaceTitleTooShortException);
    }

    // #2C - Title can not be longer than 100 characters
    [Theory]
    [InlineData("Harnessing the Power of Artificial Intelligence: Transforming Industries and Revolutionizing Everyday Life")]
    [InlineData("A Comprehensive Guide to Building Scalable Web Applications: Best Practices, Tools, and Frameworks You Need")]
    [InlineData("Understanding the Fundamentals of Quantum Computing: How It Will Change Technology and Impact Our Future")]
    public void Workspace_can_update_title_fail_2(string title)
    {
        // Arrange
        var workspace = Workspace.Create();

        // Act
        var result = workspace.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is WorkspaceTitleTooLongException);
    }

    // #2D - Title can be created with 3 and 75 characters
    [Theory]
    [InlineData("AI!")]
    [InlineData("Unlocking the Secrets of Successful Software Development: Strategies for Growth")]
    public void Workspace_can_update_title_success_2(string title)
    {
        // Arrange
        var workspace = Workspace.Create();

        // Act
        workspace.UpdateTitle(title);

        // Assert
        Assert.True(workspace.Title == title);
    }

    // #3 - Add project to workspace
    [Fact]
    public void Workspace_can_add_project()
    {
        // Arrange
        var workspace = Workspace.Create();
        var project = Project.Create();

        // Act
        workspace.AddProject(project);

        // Assert
        Assert.True(workspace.Projects.Count == 1);
    }

    // #4 - Remove project from workspace
    [Fact]
    public void Workspace_can_remove_project()
    {
        // Arrange
        var workspace = Workspace.Create();
        var project = Project.Create();
        workspace.AddProject(project);

        // Act
        workspace.RemoveProject(project);

        // Assert
        Assert.True(workspace.Projects.Count == 0);
    }

    // #5 - Add contact to workspace
    [Fact]
    public void Workspace_can_add_contact()
    {
        // Arrange
        var workspace = Workspace.Create();
        var contact = User.Create();

        // Act
        workspace.AddContact(contact);

        // Assert
        Assert.True(workspace.Contacts.Count == 1);
    }

    // #6 - Remove contact from workspace
    [Fact]
    public void Workspace_can_remove_contact()
    {
        // Arrange
        var workspace = Workspace.Create();
        var contact = User.Create();
        workspace.AddContact(contact);

        // Act
        workspace.RemoveContact(contact);

        // Assert
        Assert.True(workspace.Contacts.Count == 0);
    }

    // #7 - Add resource to workspace
    [Fact]
    public void Workspace_can_add_resource()
    {
        // Arrange
        var workspace = Workspace.Create();
        var resource = Resource.Create();

        // Act
        workspace.AddResource(resource);

        // Assert
        Assert.True(workspace.Resources.Count == 1);
    }

    // #8 - Remove resource from workspace
    [Fact]
    public void Workspace_can_remove_resource()
    {
        // Arrange
        var workspace = Workspace.Create();
        var resource = Resource.Create();
        workspace.AddResource(resource);

        // Act
        workspace.RemoveResource(resource);

        // Assert
        Assert.True(workspace.Resources.Count == 0);
    }

    // #9 - Update Owner of the workspace to user

    [Theory]
    [InlineData(OwnerType.User)]
    [InlineData(OwnerType.Organisation)]
    public void Workspace_can_update_owner_user(OwnerType type)
    {
        // Arrange
        var workspace = Workspace.Create();
        var owner = Guid.NewGuid();

        // Act
        workspace.UpdateOwner(owner,type);

        // Assert
        Assert.True(workspace.Owner == owner);
    }
}