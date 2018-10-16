using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    internal class TakeCommand : Command
    {
        public TakeCommand(string[] ids) : base(ids)
        {
        }

        public override string Execute(Player player, string[] text)
        {
            int length = text.Length;
            string itemId = "item";

            IHaveInventory container = null;

            if (length > 1)
            {
                // Take from env.
                if (length == 2 && text[1 - 1] == "take")
                {
                    // Item to get is the 2nd word
                    itemId = text[2 - 1];
                    // Container is the player's current env's
                    container = player.Location;
                }
                // Else take from a bag
                if (length >= 4 && text[1 - 1] == "take" && text[3 - 1] == "from")
                {
                    // Item to get is the 2nd word
                    itemId = text[2 - 1];
                    // Container is the 4'th word (i.e. take X from <CONTAINER>)
                    container = (IHaveInventory)(player.Locate(text[4 - 1]));
                }
            }

            if (container != null)
                return take_something_in(player, itemId, container);
            else
                return "I couldn't find the " + itemId;
        }

        /**
         * @brief   Executes the look in command
         */

        private string take_something_in(Player player, string itemId, IHaveInventory container)
        {
            // Dynamically cast the GameObj found to check if we're about to take an entire path!!
            Path pathTest = (Path)(container.Locate(itemId));

            // I'm not about to take a path!
            if (pathTest == null)
            {
                // Take the item out of its inventory into limbo (on the stack here!)
                Item itemToTake = container.Inventory.Take(itemId);

                // Given that we've actually found an item!
                if (itemToTake != null)
                {
                    // Put the item into the players inventory (back onto the heap!)
                    player.Inventory.Put(itemToTake);
                    return "Took the " + itemId;
                }
                // Else return that I can't find it
                else
                {
                    return "I couldn't find the " + itemId + " inside the " + container.Name;
                }
            }
            // Else, return that I'm not going to take a path
            else
            {
                return "I'm not strong enough to the " + itemId + "!";
            }
        }

        /**
         * @brief   Implements the interface method to provide
         *          description on how to use this command
         */

        private string description()
        {
            StringBuilder response = new StringBuilder();
            response.AppendLine("[take] " + "Usage: take <item> \n";
            response.AppendLine("       " + "       take <item> from inventory");
            response.AppendLine("       " + "       take <item> from <bag>");
            return response.ToString();
        }
    }
}