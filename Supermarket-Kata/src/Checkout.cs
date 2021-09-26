using System.Linq;
using System;
using System.Collections.Generic;

namespace SupermarketKata
{
    public interface ICheckout
    {
        /// <summary>
        /// Scans an item and adds it to list of current items;
        /// </summary>
        /// <param name="item">Item</param>
        void Scan(string item);

        /// <summary>
        /// Requires ItemPrice array for current item prices, since it changes frequently. 
        /// </summary>
        /// <param name="currentPricing">Current Prices for every SKU</param>
        /// <returns></returns>
        int GetTotalPrice(ItemPrice[] currentPricing);
    }

    public class Checkout : ICheckout
    {
        /// <summary>
        /// List of items added to the cart
        /// </summary>
        public List<ItemCount> cart= new List<ItemCount>();

        public Checkout() {}
        public void Scan(string item)
        {
            //this is either 0 skus or 1 skus
            List<ItemCount> skusThatMatchItem = (cart.Where(itemCount => itemCount.sku == item)).ToList();
            
            if (skusThatMatchItem.Count() == 0)
                cart.Add(new ItemCount(sku: item));
            else
                skusThatMatchItem.First().AddItem();

        }

        public int GetTotalPrice(ItemPrice[] currentPricing)
        {
            // initial price set to 0
            int totalPrice = 0;

            // goes through list of items in the cart and combines their price
            foreach(ItemCount item in cart)
            {
                try
                {
                    ItemPrice price = currentPricing.Where(itemPrice => itemPrice.sku == item.sku).First();

                    // if there is no special price associated with SKU then it sums their unit prices
                    if (price.specialPrice == null)
                        totalPrice += item.count * price.unitPrice;
                    else
                    {
                        //splits number of items by bundles which qualify for special prife
                        SpecialPrice specialPrice = price.specialPrice ?? new SpecialPrice(1, price.unitPrice);
                        int numberOfBundles = item.count / specialPrice.bundleUnits;
                        int remainder = item.count % specialPrice.bundleUnits;
                        
                        // total price is the sum of price of bundles and the sum of the remainder of unit prices
                        totalPrice += numberOfBundles * specialPrice.bundlePrice + remainder * price.unitPrice;
                    }
                }
                //if the scanned item SKU is not in currentPricing (does not have a price), then it assumes SKU is invalid
                catch(InvalidOperationException)
                {
                    Console.WriteLine($"ERROR: did not purchase '{item.count}x {item.sku}' as it has an invalid SKU");
                }
            }

            return totalPrice;
        }
    }
}