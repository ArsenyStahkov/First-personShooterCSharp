namespace Monsters.Items
{
    public class Armor : Item, IItem
    {
        private const int _minRandomValue = 2200;
        private const int _maxRandomValue = 2800;

        public override short Quantity { get; set; } = 15;
        public override void Generate()
        {
            Random random = new Random();
            _timer.Interval = random.Next(_minRandomValue, _maxRandomValue);
        }
    }
}