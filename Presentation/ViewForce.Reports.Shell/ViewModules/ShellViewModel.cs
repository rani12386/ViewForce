namespace ViewForce.Reports.Shell.ViewModules
{
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using ViewForce.UI.Common;

    /// <summary>
    /// Shell View Model Class 
    /// </summary>
    public class ShellViewModel
    {
        #region  private fields 

        IRegionManager _regionManager;

        #endregion

        #region Constructor

        /// <summary>
        /// ShellView Model Constructor
        /// </summary>
        /// <param name="regionManager"></param>
        public ShellViewModel(IRegionManager regionManager)
        {
            
            _regionManager = regionManager;
            Initialize();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialize regions method initializes the regions.
        /// </summary>
        private void Initialize()
        {

            this._regionManager.RegisterViewWithRegion(RegionNames.HeaderRegion,
             () => ServiceLocator.Current.GetInstance<Views.HeaderView>());

            this._regionManager.RegisterViewWithRegion(RegionNames.FooterRegion,
             () => ServiceLocator.Current.GetInstance<Views.FooterView>());

            this._regionManager.RegisterViewWithRegion(RegionNames.LeftRegion,
            () => ServiceLocator.Current.GetInstance<Views.LeftPanelView>());

            this._regionManager.RegisterViewWithRegion(RegionNames.RightRegion,
            () => ServiceLocator.Current.GetInstance<Views.RightPanelView>());
        }

        #endregion
    }
}
