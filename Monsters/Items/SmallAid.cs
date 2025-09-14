namespace Monsters.Items
{
    public class SmallAid : Item, IItem
    {
        private const int _minRandomValue = 3200;
        private const int _maxRandomValue = 3800;

        public override ushort Quantity { get; set; }

        SmallAid()
        {
            Quantity = 10;
        }

        SmallAid(ushort quantity)
        {
            Quantity = quantity;
        }

        public override void Generate()
        {
            Random random = new Random();
            _timer.Interval = random.Next(_minRandomValue, _maxRandomValue);
        }
    }
}