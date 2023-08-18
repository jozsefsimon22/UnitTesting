using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
/// Represents business logic for manipulating Person entity
/// </summary>
public interface IPersonsService
{
    /// <summary>
    /// Adds a new person into the list of persons
    /// </summary>
    /// <param name="personAddRequest">Person to add</param>
    /// <returns>Returns the same person details, along with newly generated PersonId</returns>
    PersonResponse AddPerson(PersonAddRequest? personAddRequest);

    /// <summary>
    /// Returns all persons
    /// </summary>
    /// <returns>Returns a list of objects of PersonResponse</returns>
    List<PersonResponse> GetAllPersons();   

    /// <summary>
    /// Returns PersonResponse based on the personId
    /// </summary>
    /// <param name="personId">The person's personId</param>
    /// <returns>PersonResponse object</returns>
    PersonResponse GetPersonByPersonId(Guid? personId);

    /// <summary>
    /// Returns a list of PersonResponse that matches with the search results
    /// </summary>
    /// <param name="searchBy">Field to search</param>
    /// <param name="searchString">String to search</param>
    /// <returns>Returns all matching persons based on the search string and search by</returns>
    List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString);
}