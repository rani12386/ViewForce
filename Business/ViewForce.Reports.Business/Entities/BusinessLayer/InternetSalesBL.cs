namespace ViewForce.Reports.Business.BusinessLayer
{
    using System.Collections.Generic;
    using ViewForce.Reports.Business.Entities;
    using ViewForce.Reports.Business.Interface;
    using ViewForce.Reports.Business.Mapper;
    using ViewForce.Reports.Data.DataLayer;
    using ViewForce.Reports.Data.Dto;
    using ViewForce.Reports.Data.Interface;

    /// <summary>
    /// InternetSales Business Layer class
    /// </summary>
    public class InternetSalesBL:IInternetSalesBL
    {
        /// <summary>
        /// private internetSales DAL instance
        /// </summary>
        IInternetSalesDAL internetSalesDAL = null;

        #region Public Constructor

        /// <summary>
        /// InternetSales Business Layer Constructor
        /// </summary>
        public InternetSalesBL()
        {
            internetSalesDAL = new InternetSalesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrive InternetSales
        /// </summary>
        /// <param name="searchBy"></param>
        /// <param name="searchByValue"></param>
        /// <returns>IEnumerable<InternetSalesEntity></returns>
        public IEnumerable<InternetSalesEntity> RetriveInternetSales(string searchBy, string searchByValue)
        {
            IList<InternetSalesEntity> CustomerList = new List<InternetSalesEntity>();

            foreach (InternetSalesDto source in internetSalesDAL.RetriveInternetSales(searchBy, searchByValue))
            {
                InternetSalesEntity target = new InternetSalesEntity();
                InternetSalesEntityMapper.MapDataToBusiness(source,target);
                CustomerList.Add(target);

            }
            return CustomerList;
        }

        /// <summary>
        /// Retrive Records By SearchID
        /// </summary>
        /// <param name="searchBy"></param>
        /// <returns>IEnumerable<string></returns>
        public IEnumerable<string> RetriveRecordsBySearchID(string searchBy)
        {
            IList<string> list = new List<string>();
            foreach (string source in internetSalesDAL.RetriveRecordsBySearchID(searchBy))
            {
                list.Add(source);
            }
            return list;
        }

        #endregion
    }
}
