namespace TheGame.Items;

abstract public class Item : IItem
{
    protected System.Timers.Timer _timer = new System.Timers.Timer();
    public abstract ushort Quantity { get; set; }
    public abstract void Generate();
}
