namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inverntory;

        public Location(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            Inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get { return _inverntory; }
            set { _inverntory = value; }
        }

        public GameObject Locate(string id)
        {
            return _inverntory.Fetch(id);
        }
    }
}