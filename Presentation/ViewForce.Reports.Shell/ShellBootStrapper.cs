namespace ViewForce.Reports.Shell
{
    using Microsoft.Practices.Prism.UnityExtensions;
    using System.Windows;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Prism.Modularity;

    /// <summary>
    /// Shell BootStrapper class.
    /// </summary>
    public class ShellBootStrapper : UnityBootstrapper
    {
        #region Protected Overriden Methods

        /// <summary>
        /// CreateShell method to Specify the top-level window for prism application.
        /// </summary>
        /// <returns>Dependency Object</returns>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }   

        /// <summary>
        /// InitializeShell method initializes the shell that is ready to be displayed.
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        /// <summary>
        /// ConfigureContainer method creates and return a new instance of the UnityBootstrapper
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        /// <summary>
        /// ConfigureModuleCatalog method make the registration to the ModuleCatalog
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(ReportsInitializer));
        }

        #endregion
    }
}
