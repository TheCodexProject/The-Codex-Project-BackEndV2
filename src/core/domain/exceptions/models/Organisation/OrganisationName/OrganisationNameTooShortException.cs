using System.Runtime.Serialization;

namespace domain.exceptions.models.organisation;

public class OrganisationNameTooShortException : Exception
{
    public OrganisationNameTooShortException() : base("Title is too short, it cannot be less than 2 characters.") { }
    
    public OrganisationNameTooShortException(string message) : base(message) { }
}