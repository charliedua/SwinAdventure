using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands = new List<Command>() { new MoveCommand(), new LookCommand(), new PutCommand() };

        public List<Command> Commands { get => _commands; set => _commands = value; }

        private Command FindCommand(string firstWord)
        {
            return Commands.Find(x => x.AreYou(firstWord));
        }

        public string Invoke(Player player, string text)
        {
            var textArr = text.Split(' ');
            var command = FindCommand(textArr[0]);
            if (command != null)
            {
                return command.Execute(player, textArr);
            }
            return "Can't find the command, please try again";
        }
    }
}