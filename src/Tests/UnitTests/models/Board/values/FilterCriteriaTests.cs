using domain.models.board.values;

namespace UnitTests.models.board.values;

public class FilterCriteriaTests
{
    [Fact]
    public void Create_ShouldReturnNewFilterCriteriaInstance()
    {
        // Act
        var filterCriteria = FilterCriteria.Create();

        // Assert
        Assert.NotNull(filterCriteria);
        Assert.IsType<FilterCriteria>(filterCriteria);
        Assert.NotEqual(Guid.Empty, filterCriteria.Uid);
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
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdatePropertyName(propertyName);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }

    [Theory]
    [InlineData("InvalidOperator", true)]  // Invalid operator
    [InlineData("", true)]  // Invalid operator: empty string
    [InlineData("Equals", false)]  // Valid operator
    [InlineData("Contains", false)]  // Valid operator
    [InlineData("GreaterThan", false)]  // Valid operator
    [InlineData("LessThan", false)]  // Valid operator
    public void UpdateOperator_ShouldValidateCorrectly(string @operator, bool expectedFailure)
    {
        // Arrange
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdateOperator(@operator);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }

    [Theory]
    [InlineData("", true)]  // Invalid value: empty string
    [InlineData("   ", true)]  // Invalid value: whitespace only
    [InlineData("ValidValue", false)]  // Valid value
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]  // Invalid property name: exceeds max length
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]  // Valid property name: max length
    public void UpdateValue_ShouldValidateCorrectly(string value, bool expectedFailure)
    {
        // Arrange
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdateValue(value);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }
}
