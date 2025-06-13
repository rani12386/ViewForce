namespace ViewForce.Reports.Data.Interface
{
    using System.Collections.Generic;
    using ViewForce.Reports.Data.Dto;

    /// <summary>
    /// IInternetSales DAL interface
    /// </summary>
   public interface IInternetSalesDAL
   {
       #region Methods

       /// <summary>
       /// Retrive InternetSales records
       /// </summary>
       /// <param name="SearchBy"></param>
       /// <param name="SearchByValue"></param>
       /// <returns>IEnumerable<InternetSalesDto></returns>
       IEnumerable<InternetSalesDto> RetriveInternetSales(string SearchBy, string SearchByValue);

       /// <summary>
       /// Retrive Records By SearchID
       /// </summary>
       /// <param name="SearchBy"></param>
       /// <returns>IEnumerable<string></returns>
       IEnumerable<string> RetriveRecordsBySearchID(string SearchBy);

       #endregion
   }
}
