namespace SupermarketKata {

    class ItemCount
    {
        public string sku { get; private set; }
        public int count { get; private set; }

        public ItemCount(string sku)
        {
            this.sku = sku;
            this.count = 1; //sets count to 1 when class is initialized
        }

        public void addItem()
        {
            count++;
        }
    }
}