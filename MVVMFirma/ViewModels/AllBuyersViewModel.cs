using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    #region Constructor
    public class AllBuyersViewModel : AllViewModel<Buyer>
    {
        public AllBuyersViewModel()
        : base("All buyers")
        {
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Buyer>
                (
                    garmentProducerEntities.Buyer.ToList()
                );
        }
        #endregion
    }
}
