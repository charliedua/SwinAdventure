using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "head", "leave", "move", "go" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length > 2 || text.Length < 1)
            {
                return "Cant move like that";
            }
            if (AreYou(text[0]))
            {
                Path path = (Path)p.Locate(text[1]);
                if (path != null)
                {
                    path.Move(p);
                    return $"You Head {path.Name}\n{path.FullDescription}\nYou have arrived in a {path.Destination.Name}";
                }
                else return "Cant Move there, Path locked or doesn't exist";
            }
            return null;
        }
    }
}