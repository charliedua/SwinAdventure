using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    internal class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            int length = text.Length;
            IHaveInventory container = null;
            string itemId = "";

            if (length > 1)
            {
                // Put into from env.
                if (length == 2 && text[1 - 1] == "drop")
                {
                    // Item to drop is the 2nd word
                    itemId = text[2 - 1];
                    // Container is the player's current env's
                    container = player.Location;
                }
                // Else put in a bag
                if (length >= 4 && text[1 - 1] == "put" && text[3 - 1] == "in")
                {
                    // Item to get is the 2nd word
                    itemId = text[2 - 1];
                    // Container is the 4th word
                    container = (IHaveInventory)player.Locate(text[4 - 1]);
                }
            }
            else
            {
                return "Wrong Syntax.";
            }

            // Given the container is existant
            if (container != null)
                return this.PutSomethingIn(player, itemId, container);
            else
                return "Couldn't find the " + itemId;
        }

        private string PutSomethingIn(Player player, string itemId, IHaveInventory container)
        {
            // Take the item from the players inventory
            Item itemToPut = player.Inventory.Take(itemId);

            // Found it (not NULL)... so drop it in the container and notify that you did.
            if (itemToPut != null)
            {
                container.Inventory.Put(itemToPut);
                return "I placed the " + itemId + " in " + container.Name;
            }
            // Else explicitly return that couldn't find it
            else
            {
                return "I don't have that item!";
            }
        }
    }
}