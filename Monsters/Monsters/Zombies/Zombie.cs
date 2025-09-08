using TheGame.Weapons;

namespace TheGame.Monsters.Zombies
{
    public class Zombie : Monster, IMonster
    {
        private const string _showUp = "Arrrgh!";
        protected Weapon _zombieWeapon;
        public override ushort Health => 6;

        public Zombie()
        {
            Console.WriteLine(_showUp);
        }

        public override void Attack(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (Health > 0)
            {
                Random random = new Random();
                _timer.Interval = random.Next(_delayBeforeAttack - 400, _delayBeforeAttack + 400);
                Damage = _zombieWeapon.Shoot();
                OnMonsterAttackTriggered(Damage);
            }
        }
    }
}
