using domain.models.iteration;

namespace UnitTests.models.iteration;

public class IterationTests
{
    [Fact]
    public void Create_ShouldReturnNewIterationInstance()
    {
        // Act
        var iteration = Iteration.Create();

        // Assert
        Assert.NotNull(iteration);
        Assert.IsType<Iteration>(iteration);
        Assert.NotEqual(Guid.Empty, iteration.Uid);
    }

    [Theory]
    [InlineData("", true)]  // Invalid title: empty string
    [InlineData("   ", true)]  // Invalid title: whitespace only
    [InlineData("ab", true)]  // Invalid title: less than 3 characters
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]  // Invalid title: exceeds max length
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]  // Valid title: max length
    [InlineData("ValidTitle", false)]  // Valid title
    public void UpdateTitle_ShouldValidateCorrectly(string title, bool expectedFailure)
    {
        // Arrange
        var iteration = Iteration.Create();

        // Act
        var result = iteration.UpdateTitle(title);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }

    [Fact]
    public void AddWorkItem_ShouldAddSuccessfully_WhenWorkItemIsValid()
    {
        // Arrange
        var iteration = Iteration.Create();
        var workItem = Guid.NewGuid();

        // Act
        var result = iteration.AddWorkItem(workItem);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Contains(workItem, iteration.WorkItems);
    }

    [Fact]
    public void AddWorkItem_ShouldFail_WhenWorkItemIsEmptyGuid()
    {
        // Arrange
        var iteration = Iteration.Create();
        var workItem = Guid.Empty;

        // Act
        var result = iteration.AddWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void AddWorkItem_ShouldFail_WhenWorkItemAlreadyExists()
    {
        // Arrange
        var iteration = Iteration.Create();
        var workItem = Guid.NewGuid();
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
        var workItem = Guid.NewGuid();
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
        var workItem = Guid.NewGuid();

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
        var workItem = Guid.Empty;

        // Act
        var result = iteration.RemoveWorkItem(workItem);

        // Assert
        Assert.True(result.IsFailure);
    }
}
