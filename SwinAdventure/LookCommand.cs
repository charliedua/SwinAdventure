namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            if (!(text.Length == 3 || text.Length == 5))
                return "I don’t know how to look like that";
            if (text[0].ToLower() != "look")
                return player.Location.ShortDescription;
            if (text[1].ToLower() != "at")
                return "What do you want to look at?";
            string result = "";
            IHaveInventory container;
            switch (text.Length)
            {
                case 3:
                    container = player as IHaveInventory;
                    result = LookAtIn(text[2], container);
                    if (result == null)
                        return $"I cannot find the {text[2]}";
                    break;

                case 5:
                    if (text[3].ToLower() != "in")
                        return "What do you want to look in?";
                    container = FetchContainer(player, text[4]);
                    if (container == null)
                        return $"I cannot find the {text[4]}";
                    result = LookAtIn(text[2], container);
                    if (result == null)
                        return $"I cannot find the {text[2]} in the {container.Name}";
                    break;

                default:
                    result = "I don't know how to look like that";
                    break;
            }
            return result;
        }

        private IHaveInventory FetchContainer(Player player, string containerId)
        {
            return player.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            var thing = container.Locate(thingId);
            if (thing == null)
                return null;
            return thing.FullDescription;
        }
    }
}