using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Labb4Countries.Model.ViewModels
{
    public class MainViewModel : SimpleViewModel
    {
        private Country currentCountry;
        private int currentIndex;
        private readonly List<Country> countries;
        private readonly CountryRepository countryRepository;

        public ICommand nextCommand { get; private set; }
        public ICommand previousCommand { get; private set; }

        public Country CurrentCountry
        {
            get
            {
                return currentCountry;
            }
            set
            {
                SetPropertyValue(ref currentCountry, value);
            }
        }

        public MainViewModel()
        {
            countryRepository = new CountryRepository();
            countries = countryRepository.GetCountries();
            CurrentCountry = countries[0];

            
            NextButtonClicked();
            PreviousButtonClicked();
        }

        private void NextButtonClicked()
        {
            nextCommand = new Command(() =>
            {
                if (currentIndex < countries.Count - 1)
                {
                    currentIndex++;
                    CurrentCountry = countries[currentIndex];
                }
            });
        }

        private void PreviousButtonClicked()
        {
            previousCommand = new Command(() =>
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                    CurrentCountry = countries[currentIndex];
                }
            });
        }

    }
}