namespace Monsters.Items
{
    interface IItem
    {
        abstract short Quantity { get; set; }
        abstract void Generate();
    }
}
