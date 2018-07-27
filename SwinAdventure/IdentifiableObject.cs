using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                return _identifiers.First();
            }
        }

        public IdentifiableObject(string[] idents)
        {
            _identifiers = idents.ToList();
        }

        public void AddIdentiﬁer(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }
    }
}
