using domain.models.board.values;

namespace UnitTests.models.board.values;

public class FilterCriteriaTests
{

    [Theory]
    [InlineData("")]  // Invalid property name: empty string
    [InlineData("   ")]  // Invalid property name: whitespace only
    [InlineData(null)]  // Invalid value: null
    public void UpdatePropertyName_ShouldFail_WhenNameIsEmptyOrWhitespace(string propertyName)
    {
        // Arrange
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdatePropertyName(propertyName);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Theory]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]  // Invalid property name: exceeds max length
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]  // Valid property name: max length
    [InlineData("ValidPropertyName", false)]  // Valid property name
    public void UpdatePropertyName_ShouldValidateNameLengthCorrectly(string propertyName, bool expectedFailure)
    {
        // Arrange
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdatePropertyName(propertyName);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }

    [Theory]
    [InlineData("InvalidOperator")]  // Invalid operator
    [InlineData("")]  // Invalid operator: empty string
    [InlineData(null)]  // Invalid value: null
    public void UpdateOperator_ShouldFail_WhenOperatorIsInvalidOrEmpty(string @operator)
    {
        // Arrange
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdateOperator(@operator);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Theory]
    [InlineData("Equals")]  // Valid operator
    [InlineData("Contains")]  // Valid operator
    [InlineData("GreaterThan")]  // Valid operator
    [InlineData("LessThan")]  // Valid operator
    public void UpdateOperator_ShouldPass_WhenOperatorIsValid(string @operator)
    {
        // Arrange
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdateOperator(@operator);

        // Assert
        Assert.False(result.IsFailure);
    }

    [Theory]
    [InlineData("")]  // Invalid value: empty string
    [InlineData("   ")]  // Invalid value: whitespace only
    [InlineData(null)]  // Invalid value: null
    public void UpdateValue_ShouldFail_WhenValueIsEmptyOrWhitespace(string value)
    {
        // Arrange
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdateValue(value);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Theory]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", true)]  // Invalid value: exceeds max length
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]  // Valid value: max length
    [InlineData("ValidValue", false)]  // Valid value
    public void UpdateValue_ShouldValidateValueLengthCorrectly(string value, bool expectedFailure)
    {
        // Arrange
        var filterCriteria = FilterCriteria.Create();

        // Act
        var result = filterCriteria.UpdateValue(value);

        // Assert
        Assert.Equal(expectedFailure, result.IsFailure);
    }
}
