using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class AllViewModel<T>:WorkspaceViewModel //pod T beda podstawiane konkretne typy elementow listy
    {
        #region DB
        protected readonly GarmentProducerEntities garmentProducerEntities; //to jest pole, ktore reprezentuje baze danych

        #endregion
        #region LoadCommand
        private BaseCommand _LoadCommand; // to jest komenda, ktora bedzie wywolywala funkcje Load pobierajaca z BD artkuly

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }
        #endregion
        #region List
        ObservableCollection<T> _List; // tu beda przechowywane towary pobrane z BD
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List); //to jest zlecenie odswiezenia listy na interfejsie
            }
        }
        #endregion
        #region Constructor
        public AllViewModel(String displayName)
        {
            garmentProducerEntities = new GarmentProducerEntities();
            base.DisplayName = displayName;
        }
        #endregion
        #region Helpers
        public abstract void Load();
        #endregion
    }
}
