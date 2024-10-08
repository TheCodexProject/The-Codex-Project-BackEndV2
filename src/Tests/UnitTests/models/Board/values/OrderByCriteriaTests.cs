using domain.models.board.values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.models.board.values;

public class OrderByCriteriaTests
{
    [Theory]
    [InlineData("")]  // Invalid property name: empty string
    [InlineData("   ")]  // Invalid property name: whitespace only
    [InlineData(null)]  // Invalid property name: null
    public void UpdatePropertyName_ShouldFail_WhenNameIsEmptyOrWhitespace(string propertyName)
    {
        // Arrange
        var orderByCriteria = OrderByCriteria.Create();

        // Act
        var result = orderByCriteria.UpdatePropertyName(propertyName);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Theory]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]  // Invalid property name: exceeds max length
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]  // Valid property name: max length
    [InlineData("ValidPropertyName", false)]  // Valid property name
    public void UpdatePropertyName_ShouldValidateLengthCorrectly(string propertyName, bool expectedFailure)
    {
        // Arrange
        var orderByCriteria = OrderByCriteria.Create();

        // Act
        var result = orderByCriteria.UpdatePropertyName(propertyName);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }

    [Theory]
    [InlineData(true)]  // Valid value for IsAscending
    [InlineData(false)]  // Valid value for IsAscending
    public void UpdateIsAscending_ShouldAlwaysReturnSuccess(bool isAscending)
    {
        // Arrange
        var orderByCriteria = OrderByCriteria.Create();

        // Act
        var result = orderByCriteria.UpdateIsAscending(isAscending);

        // Assert
        Assert.False(result.IsFailure);
    }
}
