

namespace SupermarketKata
{
    /// <summary>
    /// Struct <c>ItemPrice</c> contains information about unit price and special price of a specific SKU
    /// </summary>
    public struct ItemPrice
    {
        /// <summary>
        /// SKU of item
        /// </summary>
        public readonly string sku { get; init; }

        /// <summary>
        /// Unit price of item when purchased individually
        /// </summary>
        public readonly int unitPrice { get; init; }

        /// <summary>
        /// OPTIONAL: Special price of item when purchased in a bundle.
        /// No special price if null
        /// </summary>
        public readonly SpecialPrice? specialPrice { get; init; }

        /// <summary>
        /// Initializes ItemInfo object (read-only)
        /// SpecialPrice defaults to null -> means there is not a special offer when buying item in a bundle
        /// </summary>
        public ItemPrice(string sku, int unitPrice, SpecialPrice? specialPrice = null)
        {
            this.sku = sku;
            this.unitPrice = unitPrice;
            this.specialPrice = specialPrice;
        }
    }

}
