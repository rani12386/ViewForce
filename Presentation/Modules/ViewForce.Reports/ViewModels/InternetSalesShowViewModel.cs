namespace ViewForce.Reports.ViewModels
{
    using Microsoft.Practices.Prism.Events;
    using System.Collections.ObjectModel;
    using ViewForce.Reports.Business.BusinessLayer;
    using ViewForce.Reports.Business.Entities;
    using ViewForce.Reports.Business.Interface;
    using ViewForce.Reports.Infrastructure;
    using ViewForce.Reports.Infrastructure.Events;
    using ViewForce.Reports.Mapper;
    using System.Collections.Generic;
    using UIEntity = ViewForce.Reports.Entities;

    /// <summary>
    /// Internet Sales Show ViewModel
    /// </summary>
    public class InternetSalesViewModel : ViewModelBase
    {
        #region private fields
              
        /// <summary>
        /// internetSales business layer instance.
        /// </summary>
        IInternetSalesBL internetSalesBL = null;

        /// <summary>
        /// eventAggregator instance.
        /// </summary>
        IEventAggregator eventAggregator;

        #endregion

        #region Constructor

        /// <summary>
        /// InternetSalesViewModel Constructor
        /// </summary>
        /// <param name="_eventAggregator"></param>
        public InternetSalesViewModel(IEventAggregator _eventAggregator)
        {
            this.eventAggregator = _eventAggregator;
            Initialze();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get and Set InternetSales Collection 
        /// </summary>
        public ObservableCollection<UIEntity.InternetSalesEntity> InternetSalesCollection { get; set; }

        #endregion

        #region Public Methods

        public void Notify()
        {
            this.OnPropertyChanged("InternetSalesCollection");
        }

        /// <summary>
        /// Initialze method subscribe the serchevent to retrive internetsales records.
        /// </summary>
        public void Initialze()
        {

            this.eventAggregator.GetEvent<SearchEvent>().Subscribe(RetriveInternetSales, ThreadOption.UIThread);

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Retrive InternetSales records
        /// </summary>
        /// <param name="seleceteList"></param>
        private void RetriveInternetSales(IDictionary<string, string> seleceteList)
        {
            InternetSalesCollection = new ObservableCollection<UIEntity.InternetSalesEntity>();
            string selecteName = string.Empty;
            string filterName = string.Empty;
            internetSalesBL = new InternetSalesBL();
            if (seleceteList.ContainsKey("SelectedName"))
            {
                selecteName = seleceteList["SelectedName"];
            }
            if (seleceteList.ContainsKey("FilterName"))
            {
                filterName = seleceteList["FilterName"];
            }
            if (!string.IsNullOrEmpty(filterName) && !string.IsNullOrEmpty(selecteName))
            {
                foreach (InternetSalesEntity source in internetSalesBL.RetriveInternetSales(selecteName, filterName))
                {
                    UIEntity.InternetSalesEntity target = new UIEntity.InternetSalesEntity();
                    InternetSalesUIMapper.MapBusinessToUI(target, source);
                    InternetSalesCollection.Add(target);
                }
            }

            this.OnPropertyChanged("InternetSalesCollection");
        }

        #endregion
    }
}
