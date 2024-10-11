using domain.exceptions.common;
using domain.exceptions.models.workitem.description;
using domain.exceptions.models.workitem.title;
using domain.models.resource;
using domain.models.user;
using domain.models.values;
using domain.models.workitem;

namespace UnitTests.models.workitem;

public class WorkItemModelTests
{

    // # 1 - Create a new WorkItem
    [Fact]
    public void WorkItem_can_be_created()
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act

        // Assert
        Assert.NotNull(workItem);
    }

    #region WorkItem Title Tests.

    // # 2 - Title updates using the UpdateTitle method
    [Theory]
    [InlineData("The Art of Coding")]
    [InlineData("Exploring Machine Learning")]
    [InlineData("Effective Team Communication")]
    [InlineData("Cybersecurity Essentials")]
    [InlineData("Mastering Data Structures")]
    public void WorkItem_can_update_title_success(string title)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        workItem.UpdateTitle(title);

        // Assert
        Assert.True(workItem.Title == title);
    }

    // # 2A - Title can not be null or empty
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void WorkItem_Title_cannot_be_null_or_empty(string title)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is WorkItemTitleEmptyException);
    }

    // # 2B Title has to be at least 3 characters long
    [Theory]
    [InlineData("A")]
    [InlineData("AB")]
    public void WorkItem_Title_has_to_be_at_least_3_characters_long(string title)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is WorkItemTitleTooShortException);
    }

    // # 2C Title can not be longer than 75 characters
    [Theory]
    [InlineData("The Comprehensive Guide to Understanding the Intricacies of Modern Software Engineering Practices")]
    [InlineData("Exploring the Evolution of Technology: From the Dawn of Computers to the Era of Artificial Intelligence and Beyond")]
    [InlineData("A Deep Dive into the World of Quantum Computing: Principles, Applications, and Future Prospects for the Tech Industry")]
    public void WorkItem_Title_cannot_be_longer_than_75_characters(string title)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is WorkItemTitleTooLongException);
    }

    // # 2D Title can be created with 3 and 75 characters
    [Theory]
    [InlineData("AI!")]
    [InlineData("The Enigmatic Puzzle of the Vanishing Cats of Willow Creek")]
    public void WorkItem_Title_can_be_created_with_3_and_75_characters(string title)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        workItem.UpdateTitle(title);

        // Assert
        Assert.True(workItem.Title == title);
    }

    #endregion

    #region WorkItem Description Tests.

    // # 3 - Description updates using the UpdateDescription method
    [Theory]
    [InlineData("The Art of Coding")]
    [InlineData("Exploring Machine Learning")]
    [InlineData("Effective Team Communication")]
    [InlineData("Cybersecurity Essentials")]
    [InlineData("Mastering Data Structures")]
    public void WorkItem_can_update_description_success(string description)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        workItem.UpdateDescription(description);

        // Assert
        Assert.True(workItem.Description == description);
    }

    // # 3A - Description can be null
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void WorkItem_Description_can_be_null(string description)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        workItem.UpdateDescription(description);

        // Assert
        Assert.True(workItem.Description == description);
    }

    // # 3B - Description can not be longer than 500 characters
    [Fact]
    public void WorkItem_Description_cannot_be_longer_than_500_characters()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var description = new string('A', 501);

        // Act
        var result = workItem.UpdateDescription(description);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is WorkItemDescriptionTooLongException);
    }

    // # 3C - Description can be created with 500 characters
    [Fact]
    public void WorkItem_Description_can_be_created_with_500_characters()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var description = new string('A', 500);

        // Act
        workItem.UpdateDescription(description);

        // Assert
        Assert.True(workItem.Description == description);
    }

    #endregion

    // # 4 - Status updates using the UpdateStatus method
    [Theory]
    [InlineData(Status.None)]
    [InlineData(Status.Open)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.ReadyForReview)]
    [InlineData(Status.Done)]
    [InlineData(Status.Closed)]
    public void WorkItem_can_update_status_success(Status status)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        workItem.UpdateStatus(status);

        // Assert
        Assert.True(workItem.Status == status);
    }

    // # 5 - Priority updates using the UpdatePriority method
    [Theory]
    [InlineData(Priority.None)]
    [InlineData(Priority.Low)]
    [InlineData(Priority.Medium)]
    [InlineData(Priority.High)]
    [InlineData(Priority.Critical)]
    public void WorkItem_can_update_priority_success(Priority priority)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        workItem.UpdatePriority(priority);

        // Assert
        Assert.True(workItem.Priority == priority);
    }

    // # 6 - Type updates using the UpdateType method
    [Theory]
    [InlineData(ItemType.None)]
    [InlineData(ItemType.Bug)]
    [InlineData(ItemType.Story)]
    [InlineData(ItemType.Task)]
    [InlineData(ItemType.Epic)]
    public void WorkItem_can_update_type_success(ItemType type)
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        workItem.UpdateType(type);

        // Assert
        Assert.True(workItem.Type == type);
    }

    // # 7 - Assignee updates using the UpdateAssignee method
    [Fact]
    public void WorkItem_can_update_assignee_success()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var user = User.Create();

        // Act
        workItem.AssignTo(user);

        // Assert
        Assert.True(workItem.AssignedTo == user);
    }

    // # 7A - Assignee can be null
    [Fact]
    public void WorkItem_can_update_assignee_to_null()
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        workItem.AssignTo(null);

        // Assert
        Assert.True(workItem.AssignedTo == null);
    }

    #region WorkItem Subitems Tests

    // # 8 - SubItems updates using the AddSubItem method
    [Fact]
    public void WorkItem_can_add_subitem_success()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var subItem = WorkItem.Create();

        // Act
        workItem.AddSubItem(subItem);

        // Assert
        Assert.Contains(subItem, workItem.SubItems);
    }

    // # 8A - SubItems can not be null
    [Fact]
    public void WorkItem_SubItem_cannot_be_null()
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.AddSubItem(null);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    // # 8B - Sub items do not allow duplicates
    [Fact]
    public void WorkItem_does_not_allow_duplicates()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var subItem = WorkItem.Create();

        // Act
        workItem.AddSubItem(subItem);
        var result = workItem.AddSubItem(subItem);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is AlreadyExistsException);
    }

    // # 9 - SubItems updates using the RemoveSubItem method
    [Fact]
    public void WorkItem_can_remove_subitem_success()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var subItem = WorkItem.Create();

        // Act
        workItem.AddSubItem(subItem);
        workItem.RemoveSubItem(subItem);

        // Assert
        Assert.DoesNotContain(subItem, workItem.SubItems);
    }

    // # 9A - SubItems can not be null
    [Fact]
    public void WorkItem_can_not_remove_null()
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.RemoveSubItem(null);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    // # 9B - SubItems must exist in the list
    [Fact]
    public void WorkItem_subitem_must_exist_in_the_list()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var subItem = WorkItem.Create();

        // Act
        var result = workItem.RemoveSubItem(subItem);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    #endregion

    #region  WorkItem Resources Tests

    // # 10 - Resources updates using the AddResource method
    [Fact]
    public void WorkItem_can_add_resource_success()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var resource = Resource.Create();

        // Act
        workItem.AddResource(resource);

        // Assert
        Assert.Contains(resource, workItem.Resources);
    }

    // # 10A - Resources can not be null
    [Fact]
    public void WorkItem_Resource_cannot_be_null()
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.AddResource(null);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    // # 10B - Resources do not allow duplicates
    [Fact]
    public void WorkItem_does_not_allow_duplicate_resources()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var resource = Resource.Create();

        // Act
        workItem.AddResource(resource);
        var result = workItem.AddResource(resource);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is AlreadyExistsException);
    }

    // # 11 - Resources updates using the RemoveResource method
    [Fact]
    public void WorkItem_can_remove_resource_success()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var resource = Resource.Create();

        // Act
        workItem.AddResource(resource);
        workItem.RemoveResource(resource);

        // Assert
        Assert.DoesNotContain(resource, workItem.Resources);
    }

    // # 11A - Resources can not be null
    [Fact]
    public void WorkItem_can_not_remove_null_resource()
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.RemoveResource(null);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    // # 11B - Resources must exist in the list
    [Fact]
    public void WorkItem_resource_must_exist_in_the_list()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var resource = Resource.Create();

        // Act
        var result = workItem.RemoveResource(resource);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    #endregion

    #region WorkItem Dependencies Tests

    // # 12 - Dependencies updates using the AddDependency method
    [Fact]
    public void WorkItem_can_add_dependency_success()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var dependency = WorkItem.Create();

        // Act
        workItem.AddDependency(dependency);

        // Assert
        Assert.Contains(dependency, workItem.Dependencies);
    }

    // # 12A - Dependencies can not be null
    [Fact]
    public void WorkItem_Dependency_cannot_be_null()
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.AddDependency(null);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    // # 12B - Dependencies do not allow duplicates
    [Fact]
    public void WorkItem_does_not_allow_duplicate_dependencies()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var dependency = WorkItem.Create();

        // Act
        workItem.AddDependency(dependency);
        var result = workItem.AddDependency(dependency);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is AlreadyExistsException);
    }

    // # 13 - Dependencies updates using the RemoveDependency method
    [Fact]
    public void WorkItem_can_remove_dependency_success()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var dependency = WorkItem.Create();

        // Act
        workItem.AddDependency(dependency);
        workItem.RemoveDependency(dependency);

        // Assert
        Assert.DoesNotContain(dependency, workItem.Dependencies);
    }

    // # 13A - Dependencies can not be null
    [Fact]
    public void WorkItem_can_not_remove_null_dependency()
    {
        // Arrange
        var workItem = WorkItem.Create();

        // Act
        var result = workItem.RemoveDependency(null);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    // # 13B - Dependencies must exist in the list
    [Fact]
    public void WorkItem_dependency_must_exist_in_the_list()
    {
        // Arrange
        var workItem = WorkItem.Create();
        var dependency = WorkItem.Create();

        // Act
        var result = workItem.RemoveDependency(dependency);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Contains(result.Errors, x => x is NotFoundException);
    }

    #endregion





}