namespace TheGame.Base.Interfaces;

interface IMonster
{
    abstract void Attack(object source, System.Timers.ElapsedEventArgs e);
    abstract void Die();
    abstract void OnMonsterAttackTriggered(float damage);
}
