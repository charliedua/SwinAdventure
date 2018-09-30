using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    internal class Direction : IdentifiableObject
    {
        private Path Path { get; set; }

        public Direction(string[] idents) : base(idents)
        {
            Path = new Path(, idents);
        }
    }
}