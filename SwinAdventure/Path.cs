using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {
        private Location _destination;

        public Path(string[] idents) : base(idents)
        {
        }

        public Path(Location location, string[] idents) : base(idents)
        {
            _destination = location;
        }

        public Location Destination => _destination;

        public void Move(Player player)
        {
            player.Location = _destination;
        }
    }
}