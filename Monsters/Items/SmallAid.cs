namespace Monsters.Items
{
    public class SmallAid : Item, IItem
    {
        private const int _minRandomValue = 3200;
        private const int _maxRandomValue = 3800;

        public override short Quantity { get; set; } = 10;
        public override void Generate()
        {
            Random random = new Random();
            _timer.Interval = random.Next(_minRandomValue, _maxRandomValue);
        }
    }
}