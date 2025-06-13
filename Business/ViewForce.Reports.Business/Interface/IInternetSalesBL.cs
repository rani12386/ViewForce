namespace ViewForce.Reports.Business.Interface
{
    using System.Collections.Generic;
    using ViewForce.Reports.Business.Entities;

    /// <summary>
    /// IInternetSales Business Layer interface
    /// </summary>
    public interface IInternetSalesBL
    {
        #region Methods

        /// <summary>
        /// Retrive InternetSales
        /// </summary>
        /// <param name="searchBy"></param>
        /// <param name="searchByValue"></param>
        /// <returns>IEnumerable<InternetSalesEntity></returns>
        IEnumerable<InternetSalesEntity> RetriveInternetSales(string searchBy, string searchByValue);

        /// <summary>
        /// Retrive Records By SearchID
        /// </summary>
        /// <param name="searchBy"></param>
        /// <returns>IEnumerable<string></returns>
        IEnumerable<string> RetriveRecordsBySearchID(string searchBy);

        #endregion
    }
}
