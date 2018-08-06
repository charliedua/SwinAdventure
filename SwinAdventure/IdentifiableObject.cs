using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = idents.ToList();
        }

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