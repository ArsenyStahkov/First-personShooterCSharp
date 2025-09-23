using TheGame.Base.Interfaces;
using TheGame.Weapons;

namespace TheGame.Monsters.Zombies
{
    public class Zombie : Monster, IMonster
    {
        private const string _showUp = "Arrrgh!";
        protected Weapon _zombieWeapon;

        public Zombie()
        {
            _health = 6;
            Console.WriteLine(_showUp);
        }

        public override void Attack(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (_health > 0)
            {
                Random random = new Random();
                _timer.Interval = random.Next(_delayBeforeAttack - 400, _delayBeforeAttack + 400);
                _damage = _zombieWeapon.Shoot();
                OnMonsterAttackTriggered(_damage);
            }
        }
    }
}
