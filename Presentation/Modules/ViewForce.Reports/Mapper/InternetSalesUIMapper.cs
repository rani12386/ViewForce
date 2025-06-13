namespace ViewForce.Reports.Mapper
{
    using BusinessEntity = ViewForce.Reports.Business.Entities;
    using UIEntity = ViewForce.Reports.Entities;

    /// <summary>
    /// InternetSalesUI Mapper class
    /// </summary>
    public static class InternetSalesUIMapper
    {
        #region Public Static Methods

        /// <summary>
        /// MapBusinessToUI method to map business to UI.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public static void MapBusinessToUI(UIEntity.InternetSalesEntity target, BusinessEntity.InternetSalesEntity source)
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
