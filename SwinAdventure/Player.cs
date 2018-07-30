namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription => "You are carrying:\n" + Inventory.ItemList;

        public Player(string name, string desc) : 
            base(new string[] { "me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            return _inventory.Fetch(id);
        }
    }
}
