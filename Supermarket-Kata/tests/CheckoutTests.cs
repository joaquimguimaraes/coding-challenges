using System;
using Xunit;
using SupermarketKata;
using System.Collections.Generic;

namespace SupermarketKataTests
{
    public class CheckoutTests
    {
        [Fact]
        public void CheckoutTest1()
        {

            Checkout checkout = new Checkout();

            checkout.Scan("A");
            checkout.Scan("A");

            checkout.Scan("B");
            checkout.Scan("B");

            checkout.Scan("A");
            checkout.Scan("A");

            checkout.Scan("B");

            checkout.Scan("D");

            checkout.Scan("A");

            checkout.Scan("C");

          
            //Example pricing table as defined in Supermarket-Kata.md
            ItemPrice[] prices = {
                new ItemPrice(sku: "A", unitPrice: 50, specialPrice: new SpecialPrice(bundleUnits: 3, bundlePrice: 130)),
                new ItemPrice(sku: "B", unitPrice: 30, specialPrice: new SpecialPrice(bundleUnits: 2, bundlePrice: 45)),
                new ItemPrice(sku: "C", unitPrice: 20),
                new ItemPrice(sku: "D", unitPrice: 15)
            };

            int totalPrice = checkout.GetTotalPrice(prices);

            const int expectedPrice = 230 + 45 + 30 + 20 + 15;

            bool result = totalPrice == expectedPrice;

            Assert.True(result, $"Obtained total price of {totalPrice} pence does not match expected price of {expectedPrice} pence");
        }
    }
}
