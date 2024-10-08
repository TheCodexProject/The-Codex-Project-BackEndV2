
using domain.models.board.values;
using domain.models.board;

namespace UnitTests.models.board;

public class BoardModelTests
{
   
    [Theory]
    [InlineData("")]  // Invalid title: empty string
    [InlineData("   ")]  // Invalid title: whitespace only
    [InlineData(null)]  // Invalid title: whitespace only
    public void UpdateTitle_ShouldFail_WhenTitleIsEmptyOrWhitespace(string invalidTitle)
    {
        // Arrange
        var board = Board.Create();

        // Act
        var result = board.UpdateTitle(invalidTitle);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Theory]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]  // Invalid title: exceeds max length
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]  // Valid title: max length
    public void UpdateTitle_ShouldValidateTitleLength(string title, bool expectedFailure)
    {
        // Arrange
        var board = Board.Create();

        // Act
        var result = board.UpdateTitle(title);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }

    [Fact]
    public void AddFilterCriteria_ShouldAddSuccessfully_WhenFilterCriteriaIsValid()
    {
        // Arrange
        var board = Board.Create();
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = board.AddFilterCriterias(filterCriteria);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Contains(filterCriteria, board.FilterCriterias);
    }

    [Fact]
    public void AddFilterCriteria_ShouldFail_WhenFilterCriteriaIsNull()
    {
        // Arrange
        var board = Board.Create();

        // Act
        var result = board.AddFilterCriterias(null);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void AddFilterCriteria_ShouldFail_WhenFilterCriteriaAlreadyExists()
    {
        // Arrange
        var board = Board.Create();
        var filterCriteria = FilterCriteria.Create();
        board.AddFilterCriterias(filterCriteria);

        // Act
        var result = board.AddFilterCriterias(filterCriteria);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void RemoveFilterCriteria_ShouldRemoveSuccessfully_WhenFilterCriteriaExists()
    {
        // Arrange
        var board = Board.Create();
        var filterCriteria = FilterCriteria.Create();
        board.AddFilterCriterias(filterCriteria);

        // Act
        var result = board.RemoveFilterCriterias(filterCriteria);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.DoesNotContain(filterCriteria, board.FilterCriterias);
    }

    [Fact]
    public void RemoveFilterCriteria_ShouldFail_WhenFilterCriteriaDoesNotExist()
    {
        // Arrange
        var board = Board.Create();
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = board.RemoveFilterCriterias(filterCriteria);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void AddOrderByCriteria_ShouldAddSuccessfully_WhenOrderByCriteriaIsValid()
    {
        // Arrange
        var board = Board.Create();
        var orderByCriteria = OrderByCriteria.Create();

        // Act
        var result = board.AddOrderByCriterias(orderByCriteria);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Contains(orderByCriteria, board.OrderByCriterias);
    }

    [Fact]
    public void AddOrderByCriteria_ShouldFail_WhenOrderByCriteriaIsNull()
    {
        // Arrange
        var board = Board.Create();

        // Act
        var result = board.AddOrderByCriterias(null);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void AddOrderByCriteria_ShouldFail_WhenOrderByCriteriaAlreadyExists()
    {
        // Arrange
        var board = Board.Create();
        var orderByCriteria = OrderByCriteria.Create();
        board.AddOrderByCriterias(orderByCriteria);

        // Act
        var result = board.AddOrderByCriterias(orderByCriteria);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void RemoveOrderByCriteria_ShouldRemoveSuccessfully_WhenOrderByCriteriaExists()
    {
        // Arrange
        var board = Board.Create();
        var orderByCriteria = OrderByCriteria.Create();
        board.AddOrderByCriterias(orderByCriteria);

        // Act
        var result = board.RemoveOrderByCriterias(orderByCriteria);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.DoesNotContain(orderByCriteria, board.OrderByCriterias);
    }

    [Fact]
    public void RemoveOrderByCriteria_ShouldFail_WhenOrderByCriteriaDoesNotExist()
    {
        // Arrange
        var board = Board.Create();
        var orderByCriteria = OrderByCriteria.Create();

        // Act
        var result = board.RemoveOrderByCriterias(orderByCriteria);

        // Assert
        Assert.True(result.IsFailure);
    }
}
