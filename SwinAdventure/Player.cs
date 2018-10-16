using System;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string FullDescription => "You are carrying:\n" + Inventory.ItemList;

        public Inventory Inventory
        {
            get => _inventory;
            set => _inventory = value;
        }

        public Location Location
        {
            get => _location;
            set => _location = value;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            Item fetchedObj = _inventory.Fetch(id);
            if (fetchedObj != null) return fetchedObj;
            if (Location == null) return null;
            return Location.Locate(id);
        }
    }
}