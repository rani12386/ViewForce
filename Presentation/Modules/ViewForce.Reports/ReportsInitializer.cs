namespace ViewForce.Reports
{
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using ViewForce.UI.Common;

    /// <summary>
    /// Reports Initializer class 
    /// </summary>
    public class ReportsInitializer : IModule
    {
        #region Private Fields

        IRegionManager regionManager = new RegionManager();

        #endregion

        #region Public Methods

        /// <summary>
        /// Initialize method initializes the report/modules regions
        /// </summary>
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
               () => ServiceLocator.Current.GetInstance<Views.InternetSalesView>());

           this.regionManager.RegisterViewWithRegion(RegionNames.SearchRegion,
           () => ServiceLocator.Current.GetInstance<Views.SearchView>());

            this.regionManager.RegisterViewWithRegion(RegionNames.MainMenuRegion,
              () => ServiceLocator.Current.GetInstance<Views.MainMenuView>());
        }

        #endregion
    }
}
