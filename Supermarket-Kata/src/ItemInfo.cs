
/// <summary>
/// Struct <c>ItemInfo</c> contains information about a specific SKU, from unit price to special price
/// </summary>
struct ItemInfo
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
    /// OPTIONAL: Special price of item when purchased in a bundle
    /// No special price when null
    /// </summary>
    public readonly SpecialPrice? specialPrice { get; init; }

    /// <summary>
    /// Initializes ItemInfo object (read-only)
    /// SpecialPrice defaults to null -> means there is not a special offer when buying item in a bundle
    /// </summary>
    ItemInfo(string sku, int unitPrice, SpecialPrice? specialPrice = null)
    {
        this.sku = sku;
        this.unitPrice = unitPrice;
        this.specialPrice = specialPrice;
    }
}
