namespace SwinAdventure
{
    public class Player : GameObject
    {
        public Player(string name, string desc) : 
            base(new string[] { "me", "inventory"}, name, desc)
        {

        }
    }
}
