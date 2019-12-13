using System;
using System.Collections.Generic;
using Labb4Countries.Model;

namespace Labb4Countries
{
    public class CountryRepository
    {
        public List<Country> countries { get; set; }

        public List<Country> GetCountries()
        {
            var json = new JsonHelper<CountryRepository>();
            json.Deserialize("rawData.json");
            countries = json.Type.countries;
            return countries;
        }
    }
}