using domain.models.resource;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.models.resource;

public class ResourceModelTests
{

    // # 1 - Create a new resource
    [Fact]
    public void Resource_can_be_created()
    {
        // Arrange
        var resource = Resource.Create();

        // Act

        // Assert
        Assert.NotNull(resource);
    }

    // # 2 - Update the title of the resource
    [Fact]
    public void Resource_title_can_be_updated()
    {
        // Arrange
        var resource = Resource.Create();
        var title = "New Title";

        // Act
        var result = resource.UpdateTitle(title);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 2A - Title can not be empty or null
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Resource_title_can_not_be_empty_or_null(string title)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2B - Title has to be at least 3 characters long
    [Theory]
    [InlineData("a")]
    [InlineData("ab")]
    public void Resource_title_has_to_be_at_least_3_characters_long(string title)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2C - Title can not be longer than 75 characters
    [Theory]
    [InlineData("Exploring the Profound Impact of Artificial Intelligence on Modern Software Development Practices")]
    [InlineData("A Comprehensive Guide to Understanding Quantum Computing and Its Potential Transformative Power")]
    public void Resource_title_can_not_be_longer_than_75_characters(string title)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateTitle(title);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2D - Title can be between 3 and 75 characters long
    [Theory]
    [InlineData("New Title")]
    [InlineData("A New Title")]
    [InlineData("A New Title for the Resource")]
    public void Resource_title_can_be_between_3_and_75_characters_long(string title)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateTitle(title);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 3 - Update the format of the resource
    [Fact]
    public void Resource_format_can_be_updated()
    {
        // Arrange
        var resource = Resource.Create();
        var format = ".PDF";

        // Act
        var result = resource.UpdateFormat(format);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 3A - Format can not be empty or null
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Resource_format_can_not_be_empty_or_null(string format)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateFormat(format);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3B - Format has to contain a dot
    [Theory]
    [InlineData("PDF")]
    [InlineData("DOCX")]
    public void Resource_format_has_to_contain_a_dot(string format)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateFormat(format);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3C - Format has to start with a dot
    [Theory]
    [InlineData("PDF.")]
    [InlineData("DOCX.")]
    public void Resource_format_has_to_start_with_a_dot(string format)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateFormat(format);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3D - Format can not contain more than 1 dot.
    [Theory]
    [InlineData(".PDF.DOCX")]
    [InlineData(".PDF.DOCX.PPTX")]
    public void Resource_format_can_not_contain_more_than_1_dot(string format)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateFormat(format);

        // Assert
        Assert.True(result.IsFailure);
    }


    // # 3E - Format can not be shorter than 2 characters
    [Fact]
    public void Resource_format_can_not_be_shorter_than_2_characters()
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateFormat(".");

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3F - Format can not be longer than 10 characters
    [Theory]
    [InlineData(".MARKDOWN101")]
    [InlineData(".DOCUMENT64")]
    public void Resource_format_can_not_be_longer_than_10_characters(string format)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateFormat(format);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3G - Format can be between 2 and 10 characters long
    [Theory]
    [InlineData(".MD")]
    [InlineData(".DOCX")]
    [InlineData(".PDF")]
    public void Resource_format_can_be_between_2_and_10_characters_long(string format)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateFormat(format);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 4 - Update the reference of the resource
    [Fact]
    public void Resource_reference_can_be_updated()
    {
        // Arrange
        var resource = Resource.Create();
        var reference = "https://www.google.com";

        // Act
        var result = resource.UpdateReference(reference);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 4A - Reference can not be empty or null
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Resource_reference_can_not_be_empty_or_null(string reference)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateReference(reference);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 4B - Reference can not be longer than 200 characters
    [Theory]
    [InlineData("https://www.example.com/articles/the-complete-guide-to-understanding-modern-software-development-methodologies-including-agile-devops-and-emerging-technologies-in-todays-digital-era-for-software-engineers")]
    [InlineData("https://www.example.com/resources/a-deep-dive-into-machine-learning-algorithms-and-their-applications-in-modern-industries-from-healthcare-to-fintech-and-how-they-are-transforming-business-processes-and-operations")]
    public void Resource_reference_can_not_be_longer_than_200_characters(string reference)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateReference(reference);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 4C - Reference can be between 1 and 200 characters long
    [Theory]
    [InlineData("https://www.example.com")]
    [InlineData("https://www.example.com/articles")]
    [InlineData("https://www.example.com/resources")]
    public void Resource_reference_can_be_between_1_and_200_characters_long(string reference)
    {
        // Arrange
        var resource = Resource.Create();

        // Act
        var result = resource.UpdateReference(reference);

        // Assert
        Assert.True(result.IsSuccess);
    }


}