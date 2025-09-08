namespace TheGame.Monsters;

public class Demon : Monster, IMonster
{
    private const string _showUp = "Uuurgh!";
    private const string _demonDead = "Demon is dead";
    private const string _attack = "Demon is shooting!";
    public override ushort Health => 60;
    public float Damage { get; set; } = 25.0f;

    public Demon()
    {
        _delayBeforeAttack = 1600;
        Console.WriteLine(_showUp);
    }

    public override void Attack(Object source, System.Timers.ElapsedEventArgs e)
    {
        if (Health > 0)
        {
            Random random = new Random();
            _timer.Interval = random.Next(_delayBeforeAttack - _spreadForDelay, _delayBeforeAttack + _spreadForDelay);
            OnMonsterAttackTriggered(Damage);
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
