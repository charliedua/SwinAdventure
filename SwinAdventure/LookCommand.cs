namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            throw new System.NotImplementedException();
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {

        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {

        }
    }
}