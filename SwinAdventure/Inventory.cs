using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public string ItemList
        {
            get
            {
                string result = "";
                foreach (var item in _items)
                    result += "\t" + item.ShortDescription + "\n";
                return result;
            }
        }

        public Item Fetch(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id)) return item;
            }
            return null;
        }

        public bool HasItem(string id)
        {
            return _items.Find(i => i.FirstId == id) != null;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            var item = Fetch(id);
            _items.Remove(item);
            return item;
        }
    }
}