using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllSizesViewModel:AllViewModel<Size>
    {
        public AllSizesViewModel() 
            :base("All sizes")
        {
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Size>
                (
                    garmentProducerEntities.Size.ToList()
                );
        }
        #endregion
    }
}
