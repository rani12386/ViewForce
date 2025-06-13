namespace ViewForce.Reports.Data.Mapper
{
    using System.Data;
    using ViewForce.Reports.Data.Dto;
    using ViewForce.Reports.DataAccess;

    /// <summary>
    /// InternetSalesDto Mapper class
    /// </summary>
    public static class InternetSalesDtoMapper
    {
        #region Public Static Methods

        /// <summary>
        /// Map DataModel to Dto
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static InternetSalesDto MapDataModeltoDto(IDataReader source)
        {
            InternetSalesDto target = new InternetSalesDto();
            target.UnitPrice = source.GetValue<decimal>("UnitPrice");
            target.ExtendedAmount = source.GetValue<decimal>("ExtendedAmount");
            target.DiscountAmount = source.GetValue<double>("DiscountAmount");
            target.ProductStandardCost = source.GetValue<decimal>("ProductStandardCost");
            target.TotalProductCost = source.GetValue<decimal>("TotalProductCost");
            target.SalesAmount = source.GetValue<decimal>("SalesAmount");
            target.TaxAmount = source.GetValue<decimal>("TaxAmt");
            return target;
        }

        #endregion
    }
}
