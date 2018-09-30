using System.Collections.Generic;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public override string FullDescription
        {
            get { return Name + "Directions Available: " + _inventory.ItemList; }
        }

        public Location(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            Inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get => _inventory;
            set => _inventory = value;
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            return _inventory.Fetch(id);
        }
    }
}