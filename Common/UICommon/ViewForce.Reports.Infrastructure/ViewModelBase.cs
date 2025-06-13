namespace ViewForce.Reports.Infrastructure
{
    using System.ComponentModel;

    /// <summary>
    /// View Model Base abstract class
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Public Event

        /// <summary>
        /// Property Changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Method

        /// <summary>
        /// On Property Changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
