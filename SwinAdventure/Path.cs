using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwinAdventure
{
    public class Path : Item
    {
        private readonly Location _destination;
        private readonly Location _source;

        public Path(string[] idents, string name, string desc, Location source, Location destination) : base(idents, name, desc)
        {
            _destination = destination;
            _source = source;
        }

        public Location Destination { get => _destination; }

        public void Move(Player player)
        {
            player.Location = _destination;
        }
    }
}