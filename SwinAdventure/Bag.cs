namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        private Inventory _inventory;
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get
            {
                return Name + _inventory.ItemList;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            return _inventory.Fetch(id);
        }
    }
}