using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
/// Represents business logic for manipulating Country entity
/// </summary>
/// 
public interface ICountriesService
{
    /// <summary>
    /// Ads a country object to the list of countries
    /// </summary>
    /// <param name="countryAddRequest">Country object to add</param>
    /// <returns>Returns the country object after adding it (including newly generated country id)</returns>
    CountryResponse AddCountry(CountryAddRequest countryAddRequest);

    /// <summary>
    /// Returns all countries from the list
    /// </summary>
    /// <returns>Returns all countries from the list as List of CountryResponse</returns>
    List<CountryResponse> GetAllCountries();

    /// <summary>
    /// Returns a CountryResponse based on the countryId
    /// </summary>
    /// <param name="countryId">CountryId (guid) to search</param>
    /// <returns>CountryResponse</returns>
    CountryResponse? GetCountryByCountryId (Guid?  countryId);
}

