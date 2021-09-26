namespace SupermarketKata {

    /// <summary>
    /// Class <c>ItemCount</c> is used to group up items with the same sku that are in the cart.
    /// </summary>
    public class ItemCount
    {
        /// <summary>
        /// SKU of Item
        /// </summary>
        public string sku { get; private set; }

        /// <summary>
        /// Number of items with the above SKU. This number increases as user adds more items
        /// </summary>
        public int count { get; private set; }

        public ItemCount(string sku)
        {
            this.sku = sku;
            this.count = 1; //sets count to 1 when class is initialized
        }


        /// <summary>
        /// Increases <c>count</c> by 1
        /// </summary>
        public void AddItem()
        {
            count++;
        }
    }
}