namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string FullDescription
        {
            get { return Name + _inventory.ItemList; }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            return _inventory.Fetch(id);
        }
    }
}