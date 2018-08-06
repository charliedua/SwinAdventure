namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public virtual string FullDescription => _description;
        public string Name => _name;
        public string ShortDescription => $"{Name} ({FirstId})";
    }
}