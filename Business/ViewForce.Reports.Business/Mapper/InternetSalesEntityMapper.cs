namespace ViewForce.Reports.Business.Mapper
{
    using ViewForce.Reports.Business.Entities;
    using ViewForce.Reports.Data.Dto;

    /// <summary>
    /// InternetSales Entity Mapper
    /// </summary>
    public static class InternetSalesEntityMapper
    {
        #region Public Static Methods

        /// <summary>
        /// Map Data To Business
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void MapDataToBusiness(InternetSalesDto source,InternetSalesEntity target)
        {
            target.UnitPrice = source.UnitPrice;
            target.ExtendedAmount = source.ExtendedAmount;
            target.DiscountAmount = source.DiscountAmount;
            target.ProductStandardCost = source.ProductStandardCost;
            target.TotalProductCost = source.TotalProductCost;
            target.SalesAmount = source.SalesAmount;
            target.TaxAmount = source.TaxAmount;
        }

        #endregion
    }
}
