using System;
using System.Linq;
using System.Collections.Generic;

namespace SupermarketKata
{
    class Program
    {
        static void Main(string[] args)
        {

            //Example pricing table as defined in Supermarket-Kata.md
            ItemPrice[] prices = {
                new ItemPrice(sku: "A", unitPrice: 50, specialPrice: new SpecialPrice(bundleUnits: 3, bundlePrice: 130)),
                new ItemPrice(sku: "B", unitPrice: 30, specialPrice: new SpecialPrice(bundleUnits: 2, bundlePrice: 45)),
                new ItemPrice(sku: "C", unitPrice: 20),
                new ItemPrice(sku: "D", unitPrice: 15)
            };

            Checkout checkout = new Checkout();

            string[] skus = prices.Select(itemPrice => itemPrice.sku).ToArray();

            //Stops asking for user input after detecting Z
            const ConsoleKey breakKey = ConsoleKey.Z;

            Console.WriteLine($"Press the following keys:\n{skus.ToString()}.\nType '{breakKey}' and press enter when you are finished\n\nInput:");
            string input = "";
            ConsoleKey key = ConsoleKey.A;

            while (key != breakKey)
            {
                key = Console.ReadKey().Key;

                Console.Clear();

                if (key != breakKey)
                {
                    checkout.Scan(key.ToString());
                    Console.WriteLine($"\nAdded '{key}' to cart\n");

                    ShowCart(items: checkout.cart.ToArray());

                    Console.WriteLine($"\nPress '{breakKey}' to checkout");
                }
                else
                {
                    ShowCart(items: checkout.cart.ToArray());
                    Console.WriteLine($"\nTotal Price: {checkout.GetTotalPrice(prices)} pence");
                }

            }
        }

        static void ShowCart(ItemCount[] items)
        {
            Console.WriteLine("Cart:");
            foreach (ItemCount item in items)
                Console.WriteLine($"{item.count}x {item.sku}");

        }
    }
}
