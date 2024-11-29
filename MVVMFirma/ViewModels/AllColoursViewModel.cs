using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllColoursViewModel:AllViewModel<Colour>
    {
        #region Contructor
        public AllColoursViewModel()
            :base("All colours")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Colour>
                (
                    garmentProducerEntities.Colour.ToList()
                );
        }
        #endregion
    }
}
