using domain.models.board.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.models.board.values;

public class OrderByCriteriaTests
{
    [Fact]
    public void Create_ShouldReturnNewOrderByCriteriaInstance()
    {
        // Act
        var orderByCriteria = OrderByCriteria.Create();

        // Assert
        Assert.NotNull(orderByCriteria);
        Assert.IsType<OrderByCriteria>(orderByCriteria);
        Assert.NotEqual(Guid.Empty, orderByCriteria.Uid);
    }

    [Theory]
    [InlineData("", true)]  // Invalid property name: empty string
    [InlineData("   ", true)]  // Invalid property name: whitespace only
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]  // Invalid property name: exceeds max length
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]  // Valid property name: max length
    [InlineData("ValidPropertyName", false)]  // Valid property name
    public void UpdatePropertyName_ShouldValidateCorrectly(string propertyName, bool expectedFailure)
    {
        // Arrange
        var orderByCriteria = OrderByCriteria.Create();

        // Act
        var result = orderByCriteria.UpdatePropertyName(propertyName);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }

    [Theory]
    [InlineData(true, false)]  // Valid value for IsAscending
    [InlineData(false, false)]  // Valid value for IsAscending
    public void UpdateIsAscending_ShouldAlwaysReturnSuccess(bool isAscending, bool expectedFailure)
    {
        // Arrange
        var orderByCriteria = OrderByCriteria.Create();

        // Act
        var result = orderByCriteria.UpdateIsAscending(isAscending);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }
}
