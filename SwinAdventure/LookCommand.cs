namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
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
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {

        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {

        }
    }
}