using backend_lab_C01731.Models;
using backend_lab_C01731.Repositories;
using System.Diagnostics.Metrics;

namespace backend_lab_C01731.Services
{
    public class CountryService
    {
        private readonly CountryRepository _countryRepository;

        public CountryService()
        {
     
            _countryRepository = new CountryRepository();
        }

        public List<CountryModel> GetCountries()
        {
            
            return _countryRepository.GetCountries();
        }
    }
}