using System.ComponentModel.DataAnnotations;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services;

public class PersonsService : IPersonsService
{
    // Private fields
    private readonly List<Person> _persons;
    private readonly ICountriesService _countriesService;

    private PersonResponse convertPersonToPersonResponse(Person person)
    {
        PersonResponse personResponse = person.ToPersonResponse();
        personResponse.CountryName = _countriesService.GetCountryByCountryId(person.CountryId)?.CountryName;
        return personResponse;
    }

    // Constructor
    public PersonsService()
    {
        _persons = new List<Person>();
        _countriesService = new CountriesService();
    }

    public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
    {
        // Check if personAddRequest is not null
        if (personAddRequest == null)
        {
            throw new ArgumentNullException(nameof(personAddRequest));
        }

        // Validate PersonName
        ValidationHelper.ModelValidation(personAddRequest);

        // Convert personAddRequest into Person type
        Person person = personAddRequest.ToPerson();

        // Generate PersonId
        person.PersonId = Guid.NewGuid();

        // Add person to persons list
        _persons.Add(person);

        // Convert person object to personResponse
        PersonResponse personResponse = convertPersonToPersonResponse(person);

        return personResponse;

    }

    public List<PersonResponse> GetAllPersons()
    {
        return _persons.Select(temp => temp.ToPersonResponse()).ToList();
    }

    public PersonResponse GetPersonByPersonId(Guid? personId)
    {
        if (personId == null)
        {
            return null;
        }

        Person? matchPerson = _persons.FirstOrDefault(temp => temp.PersonId == personId);

        if (matchPerson == null)
        {
            return null;
        }

        PersonResponse response = matchPerson.ToPersonResponse();

        return response;
    }

    public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString)
    {
        List<PersonResponse> allPersonResponses = GetAllPersons();
        List<PersonResponse> matchingPersonResponses = allPersonResponses;

        if (string.IsNullOrEmpty(searchString) || string.IsNullOrEmpty(searchBy))
        {
            return matchingPersonResponses;
        }

        switch (searchBy)
        {
            case nameof(Person.Name):
                matchingPersonResponses = allPersonResponses.Where(temp => 
                    (!string.IsNullOrEmpty(temp.Name) ? temp.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                break;

            case nameof(Person.Email):
                matchingPersonResponses = allPersonResponses.Where(temp => 
                    (!string.IsNullOrEmpty(temp.Email) ? temp.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                break;

            case nameof(Person.DateOfBirth):
                matchingPersonResponses = allPersonResponses.Where(temp => 
                    ((temp.DateOfBirth != null) ? temp.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                break;

            case nameof(Person.Gender):
                matchingPersonResponses = allPersonResponses.Where(temp => 
                    (!string.IsNullOrEmpty(temp.Gender) ? temp.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                break;

            case nameof(Person.CountryId):
                matchingPersonResponses = allPersonResponses.Where(temp => 
                    (!string.IsNullOrEmpty(temp.CountryName) ? temp.CountryName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                break;

            case nameof(Person.Address):
                matchingPersonResponses = allPersonResponses.Where(temp => 
                    (!string.IsNullOrEmpty(temp.Address) ? temp.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                break;

            default:
                matchingPersonResponses = allPersonResponses;
                break;
        }
        return matchingPersonResponses;
    }
}