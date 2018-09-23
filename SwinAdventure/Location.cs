namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inverntory;
        private Path _path;

        public Location(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            Inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get => _inverntory;
            set => _inverntory = value;
        }

        public Path Path { get => _path; set => _path = value; }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            return _inverntory.Fetch(id);
        }
    }
}