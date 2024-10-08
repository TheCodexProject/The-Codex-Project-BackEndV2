﻿namespace domain.exceptions.common;

/// <summary>
/// This exception is to be thrown when a required field is missing.
/// DEV NOTE: To figure out which field is missing, be sure to look at the inner exception.
/// </summary>
public class RequiredFieldMissingException : Exception
{
    /// <summary>
    /// Used to make exceptions with a custom message and an inner exception.
    /// </summary>
    /// <param name="message">Exception message to be shown to the user.</param>
    /// <param name="innerException">Exception that triggered this.</param>
    public RequiredFieldMissingException(string message, Exception innerException) : base(message, innerException) { }
}