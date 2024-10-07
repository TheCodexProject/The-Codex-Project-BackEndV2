using System.Runtime.Serialization;

namespace domain.exceptions.models.organisation;

public class OrganisationNameTooLongException : Exception
{
    public OrganisationNameTooLongException() : base("Title is too long, it cannot be more than 100 characters.") { }
    
    public OrganisationNameTooLongException(string message) : base(message) { }
}