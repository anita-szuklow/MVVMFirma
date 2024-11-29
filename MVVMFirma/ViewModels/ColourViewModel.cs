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
    public class ColourViewModel:WorkspaceViewModel
    {
        #region DB
        private GarmentProducerEntities garmentProducerEntities;
        #endregion
        #region Item
        private Colour colour;
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
        public ColourViewModel()
        {
            base.DisplayName = "Colour";
            garmentProducerEntities = new GarmentProducerEntities();
            colour = new Colour();
        }
        #endregion
        #region Properties
        // dla kazdego pola na interfejsie stworzymy properties
        public String Name
        {
            get
            {
                return colour.Name;
            }
            set
            { 
                colour.Name = value;
                OnPropertyChanged(()=> Name);
            }
        }
        public String Tone
        {
            get
            {
                return colour.Tone;
            }
            set
            {
                colour.Tone = value;
                OnPropertyChanged(() => Tone);
            }
        }
        public String Description
        {
            get
            {
                return colour.Description;
            }
            set
            {
                colour.Description = value;
                OnPropertyChanged(() => Description);
            }
        }
        #endregion
        #region Helpers
        public void Save()
        { 
            garmentProducerEntities.Colour.Add(colour); //dodaje do lokalnej kolekcji
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
