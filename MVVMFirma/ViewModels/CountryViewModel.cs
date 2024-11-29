using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class CountryViewModel:WorkspaceViewModel
    {
        #region DB
        private GarmentProducerEntities garmentProducerEntities;
        #endregion
        #region Item
        private Country country;
        #endregion
        #region Command 
        //to jest komenda, ktora zostanie podpieta pod przycisk save and close i ona wywola funkcje SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }
        #endregion
        #region Constructor
        public CountryViewModel()
        {
            base.DisplayName = "Country";
            garmentProducerEntities = new GarmentProducerEntities();
            country = new Country();
        }
        #endregion
        #region Properties
        // dla kazdego pola na interfejsie stworzymy properties
        public String Name
        {
            get
            {
                return country.Name;
            }
            set
            {
                country.Name = value;
                OnPropertyChanged(() => Name);
            }
        }
        public decimal? Duty
        {
            get
            {
                return country.Duty;
            }
            set
            {
                country.Duty = value;
                OnPropertyChanged(() => Duty);
            }
        }
        #endregion
        #region Helpers
        public void Save()
        {
            garmentProducerEntities.Country.Add(country); //dodaje do lokalnej kolekcji
            garmentProducerEntities.SaveChanges(); // zapisuje zmieny do bazy danych
        }
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose(); //zamkniecie zakladki
        }
        #endregion
    }
}
