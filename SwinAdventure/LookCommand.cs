namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string result = "";
            switch (text.Length)
            {
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
            return result;
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            return "";
        }
    }
}