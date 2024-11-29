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
    public class TaxViewModel:WorkspaceViewModel
    {
        #region DB
        private GarmentProducerEntities garmentProducerEntities;
        #endregion
        #region Item
        private Tax tax;
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
        public TaxViewModel()
        {
            base.DisplayName = "Tax";
            garmentProducerEntities = new GarmentProducerEntities();
            tax = new Tax();
        }
        #endregion
        #region Properties
        // dla kazdego pola na interfejsie stworzymy properties
        public String Description
        {
            get
            {
                return tax.Description;
            }
            set
            {
                tax.Description = value;
                OnPropertyChanged(() => Description);
            }
        }
        public decimal? Rate
        {
            get
            {
                return tax.Rate;
            }
            set
            {
                tax.Rate = value;
                OnPropertyChanged(() => Rate);
            }
        }
        #endregion
        #region Helpers
        public void Save()
        {
            garmentProducerEntities.Tax.Add(tax); //dodaje do lokalnej kolekcji
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
