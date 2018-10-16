namespace SwinAdventure
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);

        Inventory Inventory { get; set; }

        string Name { get; }
    }
}