
using domain.models.board.values;
using domain.models.board;

namespace UnitTests.models.board;

public class BoardModelTests
{
    [Fact]
    public void Create_ShouldReturnNewBoardInstance()
    {
        // Act
        var board = Board.Create();

        // Assert
        Assert.NotNull(board);
        Assert.IsType<Board>(board);
        Assert.NotEqual(Guid.Empty, board.Uid);
    }

    [Theory]
    [InlineData("", true)]  // Invalid title: empty string
    [InlineData("   ", true)]  // Invalid title: whitespace only
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]  // Invalid title: exceeds max length
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]  // Valid title: max length
    [InlineData("ValidTitle", false)]  // Valid title
    public void UpdateTitle_ShouldValidateCorrectly(string title, bool expectedFailure)
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
