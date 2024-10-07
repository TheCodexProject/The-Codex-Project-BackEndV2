using domain.models.user;
using Xunit.Abstractions;

namespace UnitTests.models.user;

public class UserModelTests
{
    // # 1 - Create a new user
    [Fact]
    public void User_can_be_created()
    {
        // Arrange
        var user = User.Create();

        // Act

        // Assert
        Assert.NotNull(user);
    }

    #region User First name Tests

    // # 2 - Update the first name of the user
    [Fact]
    public void User_can_update_first_name()
    {
        // Arrange
        var user = User.Create();
        var firstName = "John";

        // Act
        var result = user.UpdateFirstName(firstName);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 2A - First name can not be null or empty
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void User_can_not_update_first_name_with_invalid_value(string firstName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateFirstName(firstName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2B - First name has to be at least 2 characters long
    [Theory]
    [InlineData("J")]
    [InlineData("A")]
    public void User_can_not_update_first_name_with_less_than_2_characters(string firstName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateFirstName(firstName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2C - First name can not be longer than 50 characters
    [Theory]
    [InlineData("J")]
    [InlineData("A")]
    public void User_can_not_update_first_name_with_more_than_50_characters(string firstName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateFirstName(firstName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2D - First name can not contain special characters
    [Theory]
    [InlineData("John!")]
    [InlineData("John@")]
    [InlineData("John#")]
    [InlineData("John$")]
    [InlineData("John%")]
    [InlineData("John^")]
    [InlineData("John&")]
    [InlineData("John*")]
    [InlineData("John(")]
    [InlineData("John)")]
    [InlineData("John_")]
    [InlineData("John+")]
    [InlineData("John=")]
    [InlineData("John[")]
    [InlineData("John]")]
    [InlineData("John{")]
    [InlineData("John}")]
    [InlineData("John|")]
    [InlineData("John\\")]
    [InlineData("John;")]
    [InlineData("John:")]
    [InlineData("John\"")]
    [InlineData("John,")]
    [InlineData("John.")]
    [InlineData("John<")]
    [InlineData("John>")]
    [InlineData("John/")]
    [InlineData("John?")]
    [InlineData("John`")]
    [InlineData("John~")]
    public void User_can_not_update_first_name_with_special_characters(string firstName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateFirstName(firstName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2E - First name can not contain numbers
    [Theory]
    [InlineData("John1")]
    [InlineData("John2")]
    [InlineData("John3")]
    [InlineData("John4")]
    [InlineData("John5")]
    [InlineData("John6")]
    [InlineData("John7")]
    [InlineData("John8")]
    [InlineData("John9")]
    [InlineData("John0")]
    public void User_can_not_update_first_name_with_numbers(string firstName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateFirstName(firstName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2F - First name can not contain spaces
    [Theory]
    [InlineData("John Doe ")]
    [InlineData(" John Doe")]
    [InlineData(" John Doe ")]
    public void User_can_not_update_first_name_with_spaces(string firstName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateFirstName(firstName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 2G - First name can be updated with 2 and 50 characters long
    [Theory]
    [InlineData("Jo")]
    [InlineData("John")]
    [InlineData("Supercalifragilisticexpialidocious")]
    public void User_can_update_first_name_with_valid_values(string firstName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateFirstName(firstName);

        // Assert
        Assert.True(result.IsSuccess);
    }

    #endregion

    #region User Last name Tests

    // # 3 - Update the last name of the user
    [Fact]
    public void User_can_update_last_name()
    {
        // Arrange
        var user = User.Create();
        var lastName = "Doe";

        // Act
        var result = user.UpdateLastName(lastName);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 3A - Last name can not be null or empty
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void User_can_not_update_last_name_with_invalid_value(string lastName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateLastName(lastName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3B - Last name has to be at least 2 characters long
    [Theory]
    [InlineData("D")]
    [InlineData("O")]
    public void User_can_not_update_last_name_with_less_than_2_characters(string lastName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateLastName(lastName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3C - Last name can not be longer than 60 characters
    [Theory]
    [InlineData("Methionylthreonylthreonylglutaminylarginyltyrosylglutamylserine")]
    [InlineData("Antidisestablishmentarianisticallyhyperunconstitutionalisticism")]
    public void User_can_not_update_last_name_with_more_than_60_characters(string lastName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateLastName(lastName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3D - Last name can not contain special characters
    [Theory]
    [InlineData("Doe!")]
    [InlineData("Doe@")]
    [InlineData("Doe#")]
    [InlineData("Doe$")]
    [InlineData("Doe%")]
    [InlineData("Doe^")]
    [InlineData("Doe&")]
    [InlineData("Doe*")]
    [InlineData("Doe(")]
    [InlineData("Doe)")]
    [InlineData("Doe_")]
    [InlineData("Doe+")]
    [InlineData("Doe=")]
    [InlineData("Doe[")]
    [InlineData("Doe]")]
    [InlineData("Doe{")]
    [InlineData("Doe}")]
    [InlineData("Doe|")]
    [InlineData("Doe\\")]
    [InlineData("Doe;")]
    [InlineData("Doe:")]
    [InlineData("Doe\"")]
    [InlineData("Doe,")]
    [InlineData("Doe.")]
    [InlineData("Doe<")]
    [InlineData("Doe>")]
    [InlineData("Doe/")]
    [InlineData("Doe?")]
    [InlineData("Doe`")]
    [InlineData("Doe~")]
    public void User_can_not_update_last_name_with_special_characters(string lastName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateLastName(lastName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3E - Last name can not contain numbers
    [Theory]
    [InlineData("Doe1")]
    [InlineData("Doe2")]
    [InlineData("Doe3")]
    [InlineData("Doe4")]
    [InlineData("Doe5")]
    [InlineData("Doe6")]
    [InlineData("Doe7")]
    [InlineData("Doe8")]
    [InlineData("Doe9")]
    [InlineData("Doe0")]
    public void User_can_not_update_last_name_with_numbers(string lastName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateLastName(lastName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3F - Last name can not contain extra spaces
    [Theory]
    [InlineData("Doe Doe ")]
    [InlineData(" Doe Doe")]
    [InlineData(" Doe Doe ")]
    public void User_can_not_update_last_name_with_spaces(string lastName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateLastName(lastName);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 3G - Last name can be updated with 3 and 60 characters long
    [Theory]
    [InlineData("Lee")]
    [InlineData("Vanderbilt-Smith")]
    [InlineData("O'Connor")]
    [InlineData("Franzheisserquintiliosandromegozonanophiliariadonaldo")]
    public void User_can_update_last_name_with_valid_values(string lastName)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateLastName(lastName);

        // Assert
        Assert.True(result.IsSuccess);
    }

    #endregion

    #region  User Email Tests

    // # 4 - Update the email of the user
    [Fact]
    public void User_can_update_email()
    {
        // Arrange
        var user = User.Create();
        var email = "valid@mail.com";

        // Act
        var result = user.UpdateEmail(email);

        // Assert
        Assert.True(result.IsSuccess);
    }

    // # 4A - Email can not be null or empty
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void User_can_not_update_email_to_null_or_empty(string email)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateEmail(email);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 4B - Email has to be a valid email
    [Theory]
    [InlineData("invalid email")]
    [InlineData("invalid.email")]
    [InlineData("invalid@mail")]
    [InlineData("invalid@mail.")]
    [InlineData("invalid@mail.c")]
    [InlineData("invalid@mail.c.")]
    public void User_can_not_update_email_to_have_invalid_format(string email)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateEmail(email);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 4C - Email can not contain special characters or have missing parts

    [Theory]
    [InlineData("missing_at_symbol.com")]  // Missing @ symbol
    [InlineData("@domain.com")]  // Empty local part
    [InlineData("localpart@")]  // Empty domain part
    [InlineData("local@part@domain.com")]  // Multiple @ symbols
    [InlineData("special&character@domain.com")]  // Invalid special character in local part
    [InlineData("localpart@dom#ain.com")]  // Special character in domain part
    [InlineData("space in a local part@domain.com")]
    public void User_can_not_update_email_to_have_missing_parts_or_invalid_characters(string email)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateEmail(email);

        // Assert
        Assert.True(result.IsFailure);
    }

    // # 4D - Email can not exceed length limits (min 5, max 254)
    [Theory]
    [InlineData("this_is_way_too_long_for_gmail_to_accept_as_a_local_part_of_an_email@domain.com", true)]  // Local part too long
    [InlineData("validlocalpart@domainwithaveryveryveryveryveryveryveryveryveryveryverylongsegment.com", true)]  // Domain part too long
    [InlineData("valid.email@domain.com", false)]  // Valid email
    [InlineData("a@b.com", false)]  // Short but valid email
    public void User_can_not_update_email_to_exceed_length_limits(string email, bool expected)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateEmail(email);

        // Assert
        Assert.Equal(expected,result.IsFailure);
    }

    // # 4E - Email can not have wrong dot placement
    [Theory]
    [InlineData("local..part@domain.com", true)] // Consecutive dots in local part
    [InlineData("localpart@domain..com", true)] // Consecutive dots in domain part
    [InlineData(".localpart@domain.com", true)] // Local part starts with a dot
    [InlineData("localpart.@domain.com", true)] // Local part ends with a dot
    [InlineData("valid.email@domain.com", false)] // Valid email with proper dots
    public void User_can_not_update_email_to_have_consecutive_dots(string email, bool expected)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateEmail(email);

        // Assert
        Assert.Equal(expected,result.IsFailure);
    }

    // # 4F - Email needs a domain that a valid TLD

    [Theory]
    [InlineData("localpart@domain.c", true)] // TLD too short
    [InlineData("localpart@domain.com", false)] // Valid TLD
    [InlineData("localpart@short.co", false)] // Valid short TLD
    public void User_can_not_update_email_to_have_invalid_TLD(string email, bool expected)
    {
        // Arrange
        var user = User.Create();

        // Act
        var result = user.UpdateEmail(email);

        // Assert
        Assert.Equal(expected,result.IsFailure);
    }
    #endregion

}