namespace TheGame.Monsters;

public class Demon : Monster, IMonster
{
    private const string _showUp = "Uuurgh!";
    private const string _demonDead = "Demon is dead";
    private const string _attack = "Demon is shooting!";

    public Demon()
    {
        _health = 60;
        _damage = 25.0f;
        _delayBeforeAttack = 1600;
        Console.WriteLine(_showUp);
    }

    public Demon(ushort health, float damage)
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
        Console.WriteLine(_demonDead);
    }
}
