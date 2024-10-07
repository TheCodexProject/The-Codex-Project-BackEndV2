

using OperationResult;

namespace UnitTests.tools;

public class ResultTests
{
   private const string ErrorMessage = "An error has occurred.";
   
   /// <summary>
   /// Test to assert that a successful result is not a failure.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Success")]
   public void Success_Result_IsFailure_Should_Be_False()
   {
      // Arrange
      var result = Result.Success();
      
      // Act
      var isFailure = result.IsFailure;
      
      // Assert
      Assert.False(isFailure);
   }
   
   /// <summary>
   /// Test to assert that a failed result is a failure.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Failure")]
   public void Failure_Result_IsFailure_Should_Be_True()
   {
      // Arrange
      var result = Result.Failure(new Exception(ErrorMessage));
      
      // Act
      var isFailure = result.IsFailure;
      
      // Assert
      Assert.True(isFailure);
   }
   
   /// <summary>
   /// Test to assert that a failed result contains an error message.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Failure")]
   public void Failure_Result_Errors_Should_Contain_Error_Message()
   {
      // Arrange
      var result = Result.Failure(new Exception(ErrorMessage));
      
      // Act
      var errors = result.Errors;
      
      // Assert
      Assert.Contains(ErrorMessage, errors.Select(e => e.Message));
   }
   
   /// <summary>
   /// Test to assert that a failed result can contain different error messages.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Failure")]
   public void Failure_Result_Errors_Should_Contain_All_Error_Messages()
   {
      // Arrange
      var errorMessages = new[] { "Error 1", "Error 2", "Error 3" };
      var result = Result.Failure(errorMessages.Select(e => new Exception(e)).ToArray());
      
      // Act
      var errors = result.Errors;
      
      // Assert
      var exceptions = errors.ToList();
      Assert.Equal(errorMessages.Length, exceptions.Count());
      Assert.All(errorMessages, em => Assert.Contains(em, exceptions.Select(e => e.Message)));
   }

   /// <summary>
   /// Test to assert that a failed result can contain different exception types.
   /// </summary>
   [Fact]
   [Trait("Result (No return value)","Failure")]
   public void Failure_Result_Errors_Can_Be_Different_Exception_Types()
   {
      // Arrange
      var errors = new Exception[] { new ArgumentException(), new InvalidOperationException(), new ArgumentNullException() };
      var result = Result.Failure(errors);
      
      // Act
      var resultErrors = result.Errors;
      
      // Assert
      var exceptions = resultErrors.ToList();
      Assert.Equal(errors.Length, exceptions.Count());
      Assert.All(errors, e => Assert.Contains(e, exceptions));
   }
}