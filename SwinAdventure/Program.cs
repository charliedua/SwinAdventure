using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("please enter your name: ");
            string name = Console.ReadLine();
            Console.Write("please enter your description: ");
            string desc = Console.ReadLine();
            Player player = new Player(name, desc);
            Item item1 = new Item(new string[] { "item1" }, "item1", "this is item 1");
            Item item2 = new Item(new string[] { "item2" }, "item2", "this is item 2");
            player.Inventory.Put(item1);
            player.Inventory.Put(item2);
            Bag bag = new Bag(new string[] { "bag" }, "bag", "this is the bag");
            Item item3 = new Item(new string[] { "item3" }, "item3", "this is item 3");
            bag.Inventory.Put(item3);
            player.Inventory.Put(bag);
            Item item4 = new Item(new string[] { "item4" }, "item4", "this is item 4");
            Location Home = new Location(new string[] { "home" }, "Home", "This is where you live");
            Location Shop = new Location(new string[] { }, "Shop", "You can shop it");
            Home.Inventory.Put(new Path(new string[] { "north", "n" }, "North", "You go through a Door", Home, Shop));
            Shop.Inventory.Put(new Path(new string[] { "south", "s" }, "South", "You go through a Door", Shop, Home));
            player.Location = Home;
            CommandProcessor processor = new CommandProcessor();
            while (true)
            {
                Console.Write("Command $ ");
                string commandText = Console.ReadLine();
                Console.WriteLine(processor.Invoke(player, commandText));
            }
        }
    }
}