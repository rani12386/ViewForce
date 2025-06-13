namespace ViewForce.Reports.Infrastructure
{
    /// <summary>
    /// ComboBox Entity Base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ComboBoxEntityBase<T> : ViewModelBase
    {
        #region Private Members
        /// <summary>
        /// id field member
        /// </summary>
        private T id;

        /// <summary>
        /// name field member
        /// </summary>
        private string name;

        #endregion

        #region Public Members

        /// <summary>
        /// Get and Set the id field member
        /// </summary>
        public T ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.OnPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Get and Set the name field member
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        #endregion
    }
}
