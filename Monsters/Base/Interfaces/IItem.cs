namespace TheGame.Base.Interfaces;

interface IItem
{
    abstract ushort Quantity { get; set; }
    abstract void Generate();
}
