using System;

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
            name = null;
            desc = null;
            Item item1 = new Item(new string[] { "item1" }, "item1", "this is item 1");
            Item item2 = new Item(new string[] { "item2" }, "item2", "this is item 2");
            player.Inventory.Put(item1);
            player.Inventory.Put(item2);
            Bag bag = new Bag(new string[] { "bag" }, "bag", "this is the bag");
            Item item3 = new Item(new string[] { "item3" }, "item3", "this is item 3");
            bag.Inventory.Put(item3);
            player.Inventory.Put(bag);
            while (true)
            {
                Console.Write("Please enter your command here > ");
                string commandText = Console.ReadLine();
                Command command = new LookCommand();
                var commandText_split = commandText.Split(new char[] { ' ' });
                Console.WriteLine(command.Execute(player, commandText_split));
            }
        }
    }
}