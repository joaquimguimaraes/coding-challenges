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

            //Stops asking for user input after detecting the breakKey (Z)
            const ConsoleKey breakKey = ConsoleKey.Z;

            Console.Clear();
            Console.WriteLine($@"
The following products are available:

{string.Join(", ", skus)}

Press their keys to add them to your cart.
Type '{breakKey}' and press enter to checkout.

Input: ");

            ConsoleKey key = ConsoleKey.A;

            // asks for user input, adds specified item to cart
            // repeat this code until checkout 
            while (key != breakKey)
            {
                key = Console.ReadKey().Key;

                Console.Clear();

                if (key != breakKey)
                {
                    checkout.Scan(key.ToString());
                    Console.WriteLine($"\nAdded '{key}' to cart\n");

                    Console.WriteLine("Cart:");
                    ShowCart(items: checkout.cart.ToArray());

                    Console.WriteLine($"\nPress '{breakKey}' to checkout");
                }
                else
                {
                    Console.WriteLine("Purchased:");
                    ShowCart(items: checkout.cart.ToArray());
                    Console.WriteLine($"\nTotal Price: {checkout.GetTotalPrice(prices)} pence\n");
                }

            }
        }

        /// <summary>
        /// Displays items added to cart in console
        /// </summary>
        static void ShowCart(ItemCount[] items)
        {
            foreach (ItemCount item in items)
                Console.WriteLine($"{item.count}x {item.sku}");

        }
    }
}
