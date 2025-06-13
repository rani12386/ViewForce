namespace ViewForce.Reports.Data.DataLayer
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using ViewForce.Reports.Data.DataLayerCore;
    using ViewForce.Reports.Data.Dto;
    using ViewForce.Reports.Data.Interface;
    using ViewForce.Reports.Data.Mapper;
    using ViewForce.Reports.DataAccess;

    /// <summary>
    /// InternetSales DAL class
    /// </summary>
    public class InternetSalesDAL : IInternetSalesDAL
    {
        #region Public Methods

        /// <summary>
        /// Retrive InternetSales
        /// </summary>
        /// <param name="SearchBy"></param>
        /// <param name="SearchByValue"></param>
        /// <returns>IEnumerable<InternetSalesDto></returns>
        public IEnumerable<InternetSalesDto> RetriveInternetSales(string SearchBy, string SearchByValue)
        {
            IList<InternetSalesDto> internetSalesList = new List<InternetSalesDto>();
            InternetSalesDALCore.RetriveInternetSales(SearchBy, SearchByValue);
            using (IDbConnection connection = new SqlConnection(DataAccessHelper.GetConnection))
            {
                using (IDataReader reader = DataAccessHelper.ExecuteReader(Constants.GetAllRecordsBySearchId, connection))
                {
                    while (reader.Read())
                    {
                        InternetSalesDto sales = InternetSalesDtoMapper.MapDataModeltoDto(reader);
                        internetSalesList.Add(sales);
                    }

                }
            }
            return internetSalesList;
        }

        /// <summary>
        /// Retrive Records By SearchID
        /// </summary>
        /// <param name="SearchBy"></param>
        /// <returns>IEnumerable<string></returns>
        public IEnumerable<string> RetriveRecordsBySearchID(string SearchBy)
        {
            IList<string> enumvalues = new List<string>();
            InternetSalesDALCore.RetriveRecordsBySearchID(SearchBy);
            using (IDbConnection connection = new SqlConnection(DataAccessHelper.GetConnection))
            {
                using (IDataReader reader = DataAccessHelper.ExecuteReader(Constants.FilterBySearchID, connection))
                {
                    while (reader.Read())
                    {
                        string Search = string.Empty;
                        Search = reader.GetString(0);
                        enumvalues.Add(Search);
                    }
                }
            }
            return enumvalues;
        }

        #endregion
    }
}
