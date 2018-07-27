using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    class IdentifiableObject
    {
        private List<string> _identifiers;

        string FirstId
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
            _identifiers.ForEach(delegate (string item)
            {
                item.ToLower();
            });
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id);
        }
    }
}
