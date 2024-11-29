using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                
                new CommandViewModel(
                    "Invoice",
                    new BaseCommand(() => this.CreateView(new InvoiceViewModel()))),

                new CommandViewModel(
                    "All Invoices",
                    new BaseCommand(() => this.ShowAllView(new AllInvoicesViewModel()))),
                
                new CommandViewModel(
                    "Supplier",
                    new BaseCommand(() => this.CreateView(new SupplierViewModel()))),

                new CommandViewModel(
                    "All Suppliers",
                    new BaseCommand(() => this.ShowAllView(new AllSuppliersViewModel()))),

                new CommandViewModel(
                    "Article",
                    new BaseCommand(() => this.CreateView(new ArticleViewModel()))),

                new CommandViewModel(
                    "All Articles",
                    new BaseCommand(() => this.ShowAllView(new AllArticlesViewModel()))),

                new CommandViewModel(
                    "Garment",
                    new BaseCommand(() => this.CreateView(new GarmentViewModel()))),

                new CommandViewModel(
                    "All Garments",
                    new BaseCommand(() => this.ShowAllView(new AllGarmentsViewModel()))),

                new CommandViewModel(
                    "Employee",
                    new BaseCommand(() => this.CreateView(new EmployeeViewModel()))),

                new CommandViewModel(
                    "All Employees",
                    new BaseCommand(() => this.ShowAllView(new AllEmployeesViewModel()))),

                new CommandViewModel(
                    "Shop",
                    new BaseCommand(() => this.CreateView(new ShopViewModel()))),

                new CommandViewModel(
                    "All Shops",
                    new BaseCommand(() => this.ShowAllView(new AllShopsViewModel()))),

                new CommandViewModel(
                    "Buyer",
                    new BaseCommand(() => this.CreateView(new BuyerViewModel()))),

                new CommandViewModel(
                    "All Buyers",
                    new BaseCommand(() => this.ShowAllView(new AllBuyersViewModel()))),

                new CommandViewModel(
                    "Sales",
                    new BaseCommand(() => this.CreateView(new SalesViewModel()))),

                new CommandViewModel(
                    "All Sales",
                    new BaseCommand(() => this.ShowAllView(new AllSalesViewModel()))),

                new CommandViewModel(
                    "Payment",
                    new BaseCommand(() => this.CreateView(new PaymentViewModel()))),

                new CommandViewModel(
                    "All Payments",
                    new BaseCommand(() => this.ShowAllView(new AllPaymentsViewModel()))),

                new CommandViewModel(
                    "Country",
                    new BaseCommand(() => this.CreateView(new CountryViewModel()))),

                new CommandViewModel(
                    "All Countries",
                    new BaseCommand(() => this.ShowAllView(new AllCountriesViewModel()))),

                new CommandViewModel(
                    "Garment type",
                    new BaseCommand(() => this.CreateView(new GarmentTypeViewModel()))),

                new CommandViewModel(
                    "All Garment Types",
                    new BaseCommand(() => this.ShowAllView(new AllGarmentTypesViewModel()))),

                new CommandViewModel(
                    "Size",
                    new BaseCommand(() => this.CreateView(new SizeViewModel()))),

                new CommandViewModel(
                    "All Sizes",
                    new BaseCommand(() => this.ShowAllView(new AllSizesViewModel()))),

                new CommandViewModel(
                    "Colour",
                    new BaseCommand(() => this.CreateView(new ColourViewModel()))),

                new CommandViewModel(
                    "All Colours",
                    new BaseCommand(() => this.ShowAllView(new AllColoursViewModel()))),

                new CommandViewModel(
                    "Status",
                    new BaseCommand(() => this.CreateView(new StatusViewModel()))),

                new CommandViewModel(
                    "All Statuses",
                    new BaseCommand(() => this.ShowAllView(new AllStatusesViewModel()))),

                new CommandViewModel(
                    "Tax",
                    new BaseCommand(() => this.CreateView(new TaxViewModel()))),

                new CommandViewModel(
                    "All Taxes",
                    new BaseCommand(() => this.ShowAllView(new AllTaxesViewModel())))
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateView(WorkspaceViewModel nowy)
        {
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }
        //private void CreateTowar()
        //{
        //    NowyTowarViewModel workspace = new NowyTowarViewModel();
        //    this.Workspaces.Add(workspace);
        //    this.SetActiveWorkspace(workspace);
        //}
        //private void CreateInvoice()
        //{
        //    InvoiceViewModel workspace = new InvoiceViewModel();
        //    this.Workspaces.Add(workspace);
        //    this.SetActiveWorkspace(workspace);
        //}
        //private void ShowAllTowar()
        //{
        //    WszystkieTowaryViewModel workspace =
        //        this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
        //        as WszystkieTowaryViewModel;
        //    if (workspace == null)
        //    {
        //        workspace = new WszystkieTowaryViewModel();
        //        this.Workspaces.Add(workspace);
        //    }

        //    this.SetActiveWorkspace(workspace);
        //}
        private void ShowAllView<T>(T nowy) where T : WorkspaceViewModel
        {
            WorkspaceViewModel existingWorkspace =
                this.Workspaces.FirstOrDefault(vm => vm.GetType() == typeof(T));
            if (existingWorkspace == null)
            {
                existingWorkspace = nowy;
                this.Workspaces.Add(nowy);
            }

            this.SetActiveWorkspace(existingWorkspace);
        }
        //private void ShowAllInvoices()
        //{
        //    AllInvoicesViewModel workspace =
        //        this.Workspaces.FirstOrDefault(vm => vm is AllInvoicesViewModel)
        //        as AllInvoicesViewModel;
        //    if (workspace == null)
        //    {
        //        workspace = new AllInvoicesViewModel();
        //        this.Workspaces.Add(workspace);
        //    }

        //    this.SetActiveWorkspace(workspace);
        //}
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
