using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllShopsViewModel:AllViewModel<Shop>
    {
        public AllShopsViewModel() 
            :base("All shops")
        {
        }
        #region Helper
        public override void Load()
        {
            List = new ObservableCollection<Shop>
                (
                    garmentProducerEntities.Shop.ToList()
                );
        }
        #endregion
    }
}
