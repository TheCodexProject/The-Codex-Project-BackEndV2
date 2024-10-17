using domain.models.iteration;
using domain.models.workitem;

namespace UnitTests.models.iteration;

public class IterationTests
{

    [Theory]
    [InlineData("")]  // Invalid title: empty string
    [InlineData("   ")]  // Invalid title: whitespace only
    [InlineData(null)]  // Invalid title: null
    public void UpdateTitle_ShouldFail_WhenTitleIsEmptyOrWhitespace(string title)
    {
        // Arrange
        var iteration = Iteration.Create();

        // Act
        var result = iteration.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Theory]
    [InlineData("ab")]  // Invalid title: less than 3 characters
    [InlineData("a")]  // Invalid title: less than 3 characters
    public void UpdateTitle_ShouldFail_WhenTitleIsTooShort(string title)
    {
        // Arrange
        var iteration = Iteration.Create();

        // Act
        var result = iteration.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void UpdateTitle_ShouldFail_WhenTitleIsTooLong()
    {
        // Arrange
        var iteration = Iteration.Create();
        var title = new string('a', 76);  // 76 characters (exceeds the maximum length of 75)

        // Act
        var result = iteration.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void UpdateTitle_ShouldSucceed_WhenTitleIsAtMaxLength()
    {
        // Arrange
        var iteration = Iteration.Create();
        var title = new string('a', 75);  // 75 characters (maximum valid length)

        // Act
        var result = iteration.UpdateTitle(title);

        // Assert
        Assert.False(result.IsFailure);
    }

    [Fact]
    public void UpdateTitle_ShouldSucceed_WhenTitleIsValid()
    {
        // Arrange
        var iteration = Iteration.Create();
        var title = "ValidTitle";  // Valid title

        // Act
        var result = iteration.UpdateTitle(title);

        // Assert
        Assert.False(result.IsFailure);
    }

    [Fact]
    public void AddWorkItem_ShouldAddSuccessfully_WhenWorkItemIsValid()
    {
        // Arrange
        var iteration = Iteration.Create();
        var workItem = WorkItem.Create();

        // Act
        var result = iteration.AddWorkItem(workItem);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Contains(workItem, iteration.WorkItems);
    }

    [Fact]
    public void AddWorkItem_ShouldFail_WhenWorkItemAlreadyExists()
    {
        // Arrange
        var iteration = Iteration.Create();
        var workItem = WorkItem.Create();
        iteration.AddWorkItem(workItem);

        // Act
        var result = iteration.AddWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void RemoveWorkItem_ShouldRemoveSuccessfully_WhenWorkItemExists()
    {
        // Arrange
        var iteration = Iteration.Create();
        var workItem = WorkItem.Create();
        iteration.AddWorkItem(workItem);

        // Act
        var result = iteration.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.DoesNotContain(workItem, iteration.WorkItems);
    }

    [Fact]
    public void RemoveWorkItem_ShouldFail_WhenWorkItemDoesNotExist()
    {
        // Arrange
        var iteration = Iteration.Create();
        var workItem = WorkItem.Create();

        // Act
        var result = iteration.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void RemoveWorkItem_ShouldFail_WhenWorkItemIsEmptyGuid()
    {
        // Arrange
        var iteration = Iteration.Create();
        var workItem = WorkItem.Create();

        // Act
        var result = iteration.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }
}
