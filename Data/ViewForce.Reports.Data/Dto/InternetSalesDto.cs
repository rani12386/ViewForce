namespace ViewForce.Reports.Data.Dto
{
    /// <summary>
    /// InternetSales Data Entity class.
    /// </summary>
    public class InternetSalesDto
    {
        #region Public Members

        /// <summary>
        /// UnitPrice field member
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// ExtendedAmount field member
        /// </summary>
        public decimal ExtendedAmount { get; set; }

        /// <summary>
        /// DiscountAmount field member
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// ProductStandardCost field member
        /// </summary>
        public decimal ProductStandardCost { get; set; }

        /// <summary>
        /// TotalProductCost field member
        /// </summary>
        public decimal TotalProductCost { get; set; }

        /// <summary>
        /// SalesAmount field member
        /// </summary>
        public decimal SalesAmount { get; set; }

        /// <summary>
        /// TaxAmount field member
        /// </summary>
        public decimal TaxAmount { get; set; }

        #endregion
    }
}
