namespace ViewForce.Reports.Business.Entities
{
    /// <summary>
    /// InternetSales Business Layer Entity class
    /// </summary>
    public class InternetSalesEntity
    {
        #region Public Members

        /// <summary>
        /// Get and Set UnitPrice field member
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Get and Set ExtendedAmount field member
        /// </summary>
        public decimal ExtendedAmount { get; set; }

        /// <summary>
        /// Get and Set DiscountAmount field membe
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Get and Set ProductStandardCost field membe
        /// </summary>
        public decimal ProductStandardCost { get; set; }

        /// <summary>
        /// Get and Set TotalProductCost field membe
        /// </summary>
        public decimal TotalProductCost { get; set; }

        /// <summary>
        /// Get and Set SalesAmount field membe
        /// </summary>
        public decimal SalesAmount { get; set; }

        /// <summary>
        /// Get and Set TaxAmount field membe
        /// </summary>
        public decimal TaxAmount { get; set; }

        #endregion
    }
}
