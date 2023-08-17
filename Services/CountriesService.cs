using Entities;
using ServicesContracts;
using ServicesContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country> _countries;

        public CountriesService()
        {
            _countries = new List<Country>();
        }
        
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            // Validation: countryAddRequest can't be null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }
            
            // Validation: CountryName can't be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }
            
            // Validation: CountryName can't be duplicate
            if (_countries.Any(c => c.CountryName == countryAddRequest.CountryName))
            {
                
            }
            
            // Convert object from countryAddRequest to Country
            Country country = countryAddRequest.ToCountry();
            
            // Generate CountryId
            country.CountryId = Guid.NewGuid();
            
            // Add country object into _countries
            _countries.Add(country);
            
            return country.ToCountryResponse();
        }
    }
}