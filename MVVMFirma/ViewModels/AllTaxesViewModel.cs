using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllTaxesViewModel:AllViewModel<Tax>
    {
        public AllTaxesViewModel() 
            :base("All taxes")
        {
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Tax>
                (
                    garmentProducerEntities.Tax.ToList()
                );
        }
        #endregion
    }
}
