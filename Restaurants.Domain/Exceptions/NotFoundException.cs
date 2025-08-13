namespace Restaurants.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentifier) : Exception($"Resource not found: {resourceType} with ID {resourceIdentifier} doesnt exist")
{
    
}