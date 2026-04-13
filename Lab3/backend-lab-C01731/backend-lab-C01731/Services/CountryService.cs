using backend_lab_C01731.Models;
using backend_lab_C01731.Repositories;

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

        public string CreateCountry(CountryModel country)
        {
            var result = string.Empty;

            try
            {
                var isCreated = _countryRepository.CreateCountry(country);

                if (!isCreated)
                {
                    result = "Error al crear el país";
                }
            }
            catch (Exception)
            {
                result = "Error creando país";
            }

            return result;
        }
    }
}

