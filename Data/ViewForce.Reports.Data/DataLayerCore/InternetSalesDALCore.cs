namespace ViewForce.Reports.Data.DataLayerCore
{
    using ViewForce.Reports.DataAccess;

    /// <summary>
    /// InternetSales DAL Core class
    /// </summary>
    public class InternetSalesDALCore
    {
        #region Public Static Methods

        /// <summary>
        /// Retrive Records By SearchID
        /// </summary>
        /// <param name="SearchBy"></param>
        public static void RetriveRecordsBySearchID(string SearchBy)
        {
            DataAccessHelper.AddInputParameters("@SearchBy", SearchBy);
        }

        /// <summary>
        /// Retrive InternetSales
        /// </summary>
        /// <param name="SearchBy"></param>
        /// <param name="SearchByValue"></param>
        public static void RetriveInternetSales(string SearchBy, string SearchByValue)
        {
            DataAccessHelper.AddInputParameters("@SearchBy", SearchBy);
            DataAccessHelper.AddInputParameters("@SearchByValue", SearchByValue);
        }

        #endregion
    }
}
