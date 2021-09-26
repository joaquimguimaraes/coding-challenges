
namespace SupermarketKata
{
    /// <summary>
    /// Struct <c>SpecialPrice</c> describes SKU's special prices when purchased in a bundle
    /// </summary>
    public struct SpecialPrice
    {
        /// <summary>
        /// Number of units necessary for special price
        /// </summary>
        public readonly int bundleUnits { get; init; }

        /// <summary>
        /// Price for whole bundle
        /// </summary>
        public readonly int bundlePrice { get; init; }

        public SpecialPrice (int bundleUnits, int bundlePrice)
        {
            this.bundleUnits = bundleUnits;
            this.bundlePrice = bundlePrice;
        }
    }
}