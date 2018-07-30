namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;

        public string Name => _name;

        private string _description;

        public virtual string FullDescription => _description;

        public string ShortDescription => $"{Name} ({FirstId})";

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
    }
}
