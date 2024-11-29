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
    //to jest klasa, ktora dostarcza danych do widoku wyswietlajacego wszystkie towary
    public class AllArticlesViewModel:AllViewModel<Article>
    {


        #region Constructor
        public AllArticlesViewModel()
            : base("All articles") { }
        #endregion
        #region Helpers
        // metoda load pobierze wszystkie artykuly z BD
        public override void Load()
        {
            List = new ObservableCollection<Article>
                (
                    garmentProducerEntities.Article.ToList()
                    // z BD pobieram article i wszystkie rekordy zaminiam na listę
                );
        }
        #endregion
    }
}
