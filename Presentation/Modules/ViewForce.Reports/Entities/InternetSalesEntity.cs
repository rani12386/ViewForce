namespace ViewForce.Reports.Entities
{
    using ViewForce.Reports.Infrastructure;

    /// <summary>
    /// InternetSales Entity class 
    /// </summary>
    public class InternetSalesEntity : ViewModelBase
    {
        #region Private Members

        /// <summary>
        /// unitPrice field member
        /// </summary>
        private decimal unitPrice;

        /// <summary>
        /// extendedAmount field member 
        /// </summary>
        private decimal extendedAmount;

        /// <summary>
        /// discountAmount field member
        /// </summary>
        private double discountAmount;

        /// <summary>
        /// productStandardCost field member
        /// </summary>
        private decimal productStandardCost;

        /// <summary>
        /// totalProductCost field member
        /// </summary>
        private decimal totalProductCost;

        /// <summary>
        /// salesAmount field member
        /// </summary>
        private decimal salesAmount;

        /// <summary>
        /// taxAmount field member
        /// </summary>
        private decimal taxAmount;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets and Sete the UnitPrice Value
        /// </summary>
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set
            {
                unitPrice = value;
                this.OnPropertyChanged("UnitPrice");
            }

        }

        /// <summary>
        /// Gets and Sete the ExtendedAmount Value
        /// </summary>
        public decimal ExtendedAmount
        {
            get { return extendedAmount; }
            set
            {
                extendedAmount = value;
                this.OnPropertyChanged("ExtendedAmount");
            }
        }

        /// <summary>
        /// Gets and Sete the DiscountAmount Value
        /// </summary>
        public double DiscountAmount
        {
            get { return discountAmount; }
            set
            {
                discountAmount = value;
                this.OnPropertyChanged("DiscountAmount");
            }
        }

        /// <summary>
        /// Gets and Sete the ProductStandardCost Value
        /// </summary>
        public decimal ProductStandardCost
        {
            get { return productStandardCost; }
            set
            {
                productStandardCost = value;
                this.OnPropertyChanged("ProductStandardCost");
            }
        }

        /// <summary>
        /// Gets and Sete the TotalProductCost Value
        /// </summary>
        public decimal TotalProductCost
        {
            get { return totalProductCost; }
            set
            {
                totalProductCost = value;
                this.OnPropertyChanged("TotalProductCost");
            }
        }

        /// <summary>
        /// Gets and Sete the SalesAmount Value
        /// </summary>
        public decimal SalesAmount
        {
            get { return salesAmount; }
            set
            {
                salesAmount = value;
                this.OnPropertyChanged("SalesAmount");
            }
        }

        /// <summary>
        /// Gets and Sete the TaxAmount Value
        /// </summary>
        public decimal TaxAmount
        {
            get { return taxAmount; }
            set
            {
                taxAmount = value;
                this.OnPropertyChanged("TaxAmount");
            }
        }

        #endregion
    }
}
