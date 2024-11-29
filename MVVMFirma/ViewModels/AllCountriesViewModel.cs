using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllCountriesViewModel:AllViewModel<Country>
    {
        public AllCountriesViewModel() 
            :base("all countries")
        {
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Country>
                (
                    garmentProducerEntities.Country.ToList()
                );
        }
        #endregion
    }
}
