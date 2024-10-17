using domain.models.milestone;
using OperationResult;
using domain.models.user;
using domain.models.workitem;

namespace UnitTests.models.milestone;

public class MilestoneTests
{
    // # 1 - Create a new milestone
    [Fact]
    public void Milestone_can_be_created()
    {
        // Arrange
        var milestone = Milestone.Create();

        // Act

        // Assert
        Assert.NotNull(milestone);
    }

    #region Milestone Title Tests

    // # 2 - Update the title of the milestone
    [Fact]
    public void Milestone_can_update_title()
    {
        // Arrange
        var milestone = Milestone.Create();
        var title = "New Milestone Title";

        // Act
        var result = milestone.UpdateTitle(title);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 2A - Title cannot be null or empty
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Milestone_cannot_update_title_with_invalid_value(string title)
    {
        // Arrange
        var milestone = Milestone.Create();

        // Act
        var result = milestone.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2B - Title must be at least 3 characters long
    [Theory]
    [InlineData("A")]
    [InlineData("AB")]
    public void Milestone_cannot_update_title_with_less_than_3_characters(string title)
    {
        // Arrange
        var milestone = Milestone.Create();

        // Act
        var result = milestone.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2C - Title cannot be longer than 75 characters
    [Fact]
    public void Milestone_cannot_update_title_with_more_than_75_characters()
    {
        // Arrange
        var milestone = Milestone.Create();
        var title = new string('A', 76);

        // Act
        var result = milestone.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2D - Title can be updated with valid length
    [Theory]
    [InlineData("Valid Title")]
    [InlineData("This is a valid milestone title that is not too long or too short")]
    public void Milestone_can_update_title_with_valid_values(string title)
    {
        // Arrange
        var milestone = Milestone.Create();

        // Act
        var result = milestone.UpdateTitle(title);

        // Assert
        Assert.True(result.IsSuccess);
    }

    #endregion

    #region Milestone WorkItems Tests

    // # 4 - Add a work item to the milestone
    [Fact]
    public void Milestone_can_add_work_item()
    {
        // Arrange
        var milestone = Milestone.Create();
        var workItem = WorkItem.Create();

        // Act
        var result = milestone.AddWorkItem(workItem);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Contains(workItem, milestone.WorkItems);
    }

    // # 4A - Cannot add null work item
    [Fact]
    public void Milestone_cannot_add_null_work_item()
    {
        // Arrange
        var milestone = Milestone.Create();

        // Act
        var result = milestone.AddWorkItem(null);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 5 - Remove a work item from the milestone
    [Fact]
    public void Milestone_can_remove_work_item()
    {
        // Arrange
        var milestone = Milestone.Create();
        var workItem = WorkItem.Create();
        milestone.AddWorkItem(workItem);

        // Act
        var result = milestone.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.DoesNotContain(workItem, milestone.WorkItems);
    }

    // # 5A - Cannot remove a non-existent work item
    [Fact]
    public void Milestone_cannot_remove_nonexistent_work_item()
    {
        // Arrange
        var milestone = Milestone.Create();
        var workItem = WorkItem.Create();

        // Act
        var result = milestone.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }

    #endregion
}