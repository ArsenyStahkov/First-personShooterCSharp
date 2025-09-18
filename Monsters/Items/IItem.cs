namespace TheGame.Items;

interface IItem
{
    abstract ushort Quantity { get; set; }
    abstract void Generate();
}
