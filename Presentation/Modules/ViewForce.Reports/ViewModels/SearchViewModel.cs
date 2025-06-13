namespace ViewForce.Reports.ViewModels
{
    using Microsoft.Practices.Prism.Events;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using ViewForce.Reports.Business.BusinessLayer;
    using ViewForce.Reports.Business.Interface;
    using ViewForce.Reports.Infrastructure;
    using ViewForce.Reports.Infrastructure.Events;

    /// <summary>
    /// SearchViewModel class contain the code for SerchView.
    /// </summary>
    public class SearchViewModel : ViewModelBase
    {
        /// <summary>
        ///Public Collections.------- 
        /// </summary>
        public ObservableCollection<ComboBoxEntityBase<string>> ListBoxFilterCollection { get; set; }

        public ObservableCollection<string> SearchValuesCollection = new ObservableCollection<string>();

        public ObservableCollection<ComboBoxEntityBase<int>> SearchCollection { get; set; }

        #region Private Fields

        IEventAggregator eventAggregator;

        #endregion

        #region Private Members

        /// <summary>
        /// isDropDownOpen field member
        /// </summary>
        private bool isDropDownOpen;

        /// <summary>
        /// isSearchyTextVisible field member
        /// </summary>
        private bool isSearchyTextVisible;

        /// <summary>
        /// filterName field member
        /// </summary>
        private string filterName;

        /// <summary>
        /// isListBoxVisible field member
        /// </summary>
        private bool isListBoxVisible;

        /// <summary>
        /// filterselectedItem field member of type ComboBoxEntityBase<string>
        /// </summary>
        private ComboBoxEntityBase<string> filterselectedItem = new ComboBoxEntityBase<string>();

        /// <summary>
        /// selectedItem field member of type ComboBoxEntityBase<string>
        /// </summary>
        private ComboBoxEntityBase<int> selectedItem = new ComboBoxEntityBase<int>();

        #endregion

        #region Public  Properties

        /// <summary>
        /// Gets and Sete the IsDropDownOpen Value
        /// </summary>
        public bool IsDropDownOpen
        {
            get { return isDropDownOpen; }
            set { isDropDownOpen = value; this.OnPropertyChanged("IsDropDownOpen"); }
        }

        /// <summary>
        /// Gets and Sete the IsSearchyTextVisible Value
        /// </summary>
        public bool IsSearchyTextVisible
        {
            get
            {
                return this.isSearchyTextVisible;
            }
            set
            {
                this.isSearchyTextVisible = value;
                this.OnPropertyChanged("IsSearchyTextVisible");
            }
        }

        /// <summary>
        /// Gets and Sete the FilterName Value
        /// </summary>
        public string FilterName
        {
            get
            {
                return this.filterName;
            }
            set
            {
                this.filterName = value;
                this.OnPropertyChanged("FilterName");
            }
        }

        /// <summary>
        /// Gets and Sete the IsListBoxVisible Value
        /// </summary>
        public bool IsListBoxVisible
        {
            get
            {
                return this.isListBoxVisible;
            }
            set
            {
                this.isListBoxVisible = value;
                this.OnPropertyChanged("IsListBoxVisible");
            }
        }

        /// <summary>
        /// Gets and Sete the SelectedItem Value of type ComboBoxEntityBase<int>
        /// </summary>
        public ComboBoxEntityBase<int> SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                this.OnPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Gets and Sete the FilterselectedItem Value of type ComboBoxEntityBase<string>
        /// </summary>
        public ComboBoxEntityBase<string> FilterselectedItem
        {
            get
            {
                return this.filterselectedItem;
            }
            set
            {
                this.filterselectedItem = value;
                this.OnPropertyChanged("FilterselectedItem");
            }
        }

        #endregion

        #region Private Commands Members

        /// <summary>
        /// searchCommand Command Member
        /// </summary>
        private RelayCommand searchCommand = null;

        /// <summary>
        ///  comboBoxSelectionChangedCommand Command Member
        /// </summary>
        private RelayCommand comboBoxSelectionChangedCommand = null;

        /// <summary>
        ///  textChangedCommand Command Member
        /// </summary>
        private RelayCommand textChangedCommand = null;

        #endregion

        #region Public Commands Properties

        /// <summary>
        /// Get the ComboBoxSelectionChangedCommand 
        /// </summary>
        public RelayCommand ComboBoxSelectionChangedCommand
        {
            get
            {
                return (this.comboBoxSelectionChangedCommand ?? new RelayCommand(param => this.RetriveRecordsBySearchID()));
            }
        }

        /// <summary>
        /// Get the TextChangedCommand 
        /// </summary>
        public RelayCommand TextChangedCommand
        {
            get
            {
                return (this.textChangedCommand ?? new RelayCommand(param => this.TextChangedFilter()));
            }
        }

        /// <summary>
        /// Get the SearchCommand 
        /// </summary>
        public RelayCommand SearchCommand
        {
            get
            {
                return this.searchCommand ?? new RelayCommand(param => this.RetriveInternetSales());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// LoadFilter method loads the values to the serchby combobox.
        /// </summary>
        private void LoadFilter()
        {
            SearchCollection = new ObservableCollection<ComboBoxEntityBase<int>> 
            {
                new ComboBoxEntityBase<int>{ID=1, Name="Name" },
                new ComboBoxEntityBase<int>{ID=2, Name="Date" },              
                new ComboBoxEntityBase<int>{ID=3, Name="CalenderSemester"},
                new ComboBoxEntityBase<int>{ID=4, Name="CalenderQuarter"},
                new ComboBoxEntityBase<int>{ID=5, Name="SalesOrderNumber"},
            };
        }

        /// <summary>
        /// TextChangedFilter method filters the comoboxlist based on entered text/charecter and fill the resulted list to Serchvalue combobox.
        /// </summary>
        private void TextChangedFilter()
        {
            ListBoxFilterCollection = new ObservableCollection<ComboBoxEntityBase<string>>();
            this.OnPropertyChanged("FilterName");
            foreach (string item in SearchValuesCollection)
            {
                if (!string.IsNullOrEmpty(FilterName))
                {
                    if (item.StartsWith(FilterName))
                    {
                        ListBoxFilterCollection.Add(new ComboBoxEntityBase<string> { Name = item });
                    }
                }
            }
            if (ListBoxFilterCollection.Count > 0)
            {
                this.IsDropDownOpen = true;
                this.IsSearchyTextVisible = false;
                this.IsListBoxVisible = true;
            }
            this.OnPropertyChanged("ListBoxFilterCollection");
        }

        #endregion

        #region Constructor

        /// <summary>
        /// SearchViewModel Constructor
        /// </summary>
        /// <param name="_eventAggregator"></param>
        public SearchViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
            this.IsDropDownOpen = false;
            this.IsSearchyTextVisible = true;
            this.IsListBoxVisible = false;
            LoadFilter();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// RetriveInternetSales method retrives the internetsales records.
        /// </summary>
        public void RetriveInternetSales()
        {
            Dictionary<string, string> selectedIteList = null;
            selectedIteList = new Dictionary<string, string>();
            selectedIteList.Add("SelectedName", this.SelectedItem.Name);
            selectedIteList.Add("FilterName", this.FilterselectedItem.Name);
            this.eventAggregator.GetEvent<SearchEvent>().Publish(selectedIteList);
        }

        /// <summary>
        /// RetriveRecordsBySearchID method retrive the list based on selected id/searchby.
        /// </summary>
        public void RetriveRecordsBySearchID()
        {
            IInternetSalesBL internetSalesBL = new InternetSalesBL();
            IEnumerable<string> searchList = internetSalesBL.RetriveRecordsBySearchID(this.SelectedItem.Name);
            SearchValuesCollection = new ObservableCollection<string>(searchList.Distinct().ToList());
            this.IsSearchyTextVisible = true;
            this.IsListBoxVisible = false;
        }

        #endregion
    }
}
