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
    public class ShopViewModel:WorkspaceViewModel
    {
        #region DB
        private GarmentProducerEntities garmentProducerEntities;
        #endregion
        #region Item
        private Shop shop;
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
        public ShopViewModel()
        {
            base.DisplayName = "Shop";
            garmentProducerEntities = new GarmentProducerEntities();
            shop = new Shop();
        }
        #endregion
        #region Properties
        // dla kazdego pola na interfejsie stworzymy properties
        public String Name
        {
            get
            {
                return shop.Name;
            }
            set
            {
                shop.Name = value;
                OnPropertyChanged(() => Name);
            }
        }
        public String Address
        {
            get
            {
                return shop.Address;
            }
            set
            {
                shop.Address = value;
                OnPropertyChanged(() => Address);
            }
        }
        #endregion
        #region Helpers
        public void Save()
        {
            garmentProducerEntities.Shop.Add(shop); //dodaje do lokalnej kolekcji
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
