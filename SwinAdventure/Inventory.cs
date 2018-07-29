using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public string ItemList
        {
            get
            {
                return _items.ToString();
            }
        }
        public Inventory()
        {

        }

        public bool HasItem(string id)
        {
            return false;
        }

        public void Put(Item itm)
        {

        }

        public Item Take(string id)
        {

        }

        public Item Fetch(string id)
        {
            
        }
    }
}