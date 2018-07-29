namespace SwinAdventure
{
    public class Player : GameObject
    {
        private Inventory _inventory;

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get
            {
                return base.FullDescription;
            }
        }

        public Player(string name, string desc) : 
            base(new string[] { "me", "inventory"}, name, desc)
        {

        }

        public GameObject Locate(string id)
        {

        }
    }
}
