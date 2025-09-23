using TheGame.Base.Interfaces;

namespace TheGame.Monsters;

public class Imp : Monster, IMonster
{
    private const string _showUp = "Rrrargh!";
    private const string _impIsDead = "Imp is dead";
    private const string _attack = "Imp is shooting!";

    public Imp()
    {
        _health = 10;
        _damage = 15.0f;
        _delayBeforeAttack = 1600;
        Console.WriteLine(_showUp);
    }

    public Imp(ushort health, float damage)
    {
        _health = health;
        _damage = damage;
        _delayBeforeAttack = 1600;
        Console.WriteLine(_showUp);
    }

    public override void Attack(Object source, System.Timers.ElapsedEventArgs e)
    {
        if (_health > 0)
        {
            Random random = new Random();
            _timer.Interval = random.Next(_delayBeforeAttack - _spreadForDelay, _delayBeforeAttack + _spreadForDelay);
            OnMonsterAttackTriggered(_damage);
            Console.WriteLine(_attack);
        }
    }

    public override void Die()
    {
        _timer.Stop();
        _timer.Dispose();
        Console.WriteLine(_impIsDead);
    }
}
