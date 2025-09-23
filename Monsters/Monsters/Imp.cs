using TheGame.Base.Interfaces;

namespace TheGame.Monsters;

public class Imp : Monster, IMonster
{
    private const ushort _fixedHealth = 10;
    private const float _fixedDamage = 15.0f;
    private const int _fixedDelay = 1600;
    private const string _showUp = "Rrrargh!";
    private const string _impIsDead = "Imp is dead";
    private const string _attack = "Imp is shooting!";

    public Imp()
    {
        _health = _fixedHealth;
        _damage = _fixedDamage;
        _delayBeforeAttack = _fixedDelay;
        Console.WriteLine(_showUp);
    }

    public Imp(ushort health, float damage)
    {
        _health = health > 0 ? health : _fixedHealth;
        _damage = damage > 0 ? damage : _fixedDamage;
        _delayBeforeAttack = _fixedDelay;
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
