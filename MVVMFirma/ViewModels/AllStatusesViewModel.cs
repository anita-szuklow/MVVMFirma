using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllStatusesViewModel:AllViewModel<Status>
    {
        public AllStatusesViewModel() 
            :base("All statuses")
        {
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Status>
                (
                    garmentProducerEntities.Status.ToList()
                );
        }
        #endregion
    }
}
