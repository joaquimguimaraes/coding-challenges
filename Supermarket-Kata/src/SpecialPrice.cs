/// <summary>
/// Struct <c>SpecialPrice</c> describes SKU's special prices when purchased in a bundle
/// </summary>
struct SpecialPrice {
    /// <summary>
    /// Number of units necessary for special price
    /// </summary>
    public readonly int comboUnits { get; init; }

    /// <summary>
    /// Price for whole bundle
    /// </summary>
    public readonly int comboPrice { get; init; }

    SpecialPrice(int comboUnits, int comboPrice)
    {
        this.comboUnits = comboUnits;
        this.comboPrice = comboPrice;
    }
}