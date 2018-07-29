namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        private string _description;

        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }

        public string ShortDescription
        {
            get
            {
                return _description;
            }
        }

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
    }
}
