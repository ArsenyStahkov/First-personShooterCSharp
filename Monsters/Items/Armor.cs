using TheGame.Base.Interfaces;

namespace TheGame.Items;

public class Armor : Item, IItem
{
    private const int _minRandomValue = 2200;
    private const int _maxRandomValue = 2800;

    public override ushort Quantity { get; set; }

    Armor()
    {
        Quantity = 15;
    }

    Armor(ushort quantity)
    {
        Quantity = quantity;
    }

    public override void Generate()
    {
        Random random = new Random();
        _timer.Interval = random.Next(_minRandomValue, _maxRandomValue);
    }
}
