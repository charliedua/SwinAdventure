namespace SwinAdventure
{
    public class Player : GameObject
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
            if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else if (id == "me" || id == "inventory")
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
