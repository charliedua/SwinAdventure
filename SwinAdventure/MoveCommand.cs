using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand(string[] ids) : base(ids)
        {
        }

        public MoveCommand() : base(new string[] { "head", "leave", "move", "go" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length > 2)
            {
                return "Cant move like that";
            }
            if (AreYou(text[0]))
            {
            }
            return null;
        }

        private void Move(Player player, string destination)
        {
            player.Location =
        }
    }
}