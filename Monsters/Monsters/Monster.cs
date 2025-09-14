namespace TheGame.Monsters;

public abstract class Monster : IMonster
{
    protected ushort _health;
    protected float _damage;
    protected int _delayBeforeAttack;
    protected int _spreadForDelay;

    protected System.Timers.Timer _timer = new System.Timers.Timer();

    public delegate void DelegateAttack(float damage);
    public event DelegateAttack MonsterAttacked;

    public Monster()
    {
        _spreadForDelay = 400;

        _timer.Elapsed += Attack;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    public abstract void Attack(Object source, System.Timers.ElapsedEventArgs e);
    public virtual void Die()
    {
    }

    public void OnMonsterAttackTriggered(float damage)
    {
        MonsterAttacked?.Invoke(damage);
    }
}