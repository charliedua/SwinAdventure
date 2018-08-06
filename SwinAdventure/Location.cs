namespace SwinAdventure
{
    public class Location : IdentifiableObject
    {
        private string _name;
        private string _desc;

        public Location(string[] idents) : base(idents)
        {
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }
    }
}