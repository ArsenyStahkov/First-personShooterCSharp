namespace TheGame.Monsters;

public class Imp : Monster, IMonster
{
    private const string _showUp = "Rrrargh!";
    private const string _impIsDead = "Imp is dead";
    private const string _attack = "Imp is shooting!";
    public override ushort Health => 10;
    public float Damage { get; set; } = 15.0f;

    public Imp()
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
        Console.WriteLine(_impIsDead);
    }
}
