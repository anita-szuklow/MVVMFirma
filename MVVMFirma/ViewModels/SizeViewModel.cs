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
    public class SizeViewModel:WorkspaceViewModel
    {
        #region DB
        private GarmentProducerEntities garmentProducerEntities;
        #endregion
        #region Item
        private Size size;
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
        public SizeViewModel()
        {
            base.DisplayName = "Size";
            garmentProducerEntities = new GarmentProducerEntities();
            size = new Size();
        }
        #endregion
        #region Properties
        // dla kazdego pola na interfejsie stworzymy properties
        public String Name
        {
            get
            {
                return size.Name;
            }
            set
            {
                size.Name = value;
                OnPropertyChanged(() => Name);
            }
        }
        public String Description
        {
            get
            {
                return size.Description;
            }
            set
            {
                size.Description = value;
                OnPropertyChanged(() => Description);
            }
        }
        #endregion
        #region Helpers
        public void Save()
        {
            garmentProducerEntities.Size.Add(size); //dodaje do lokalnej kolekcji
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
