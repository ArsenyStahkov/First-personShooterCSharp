namespace TheGame.Monsters
{
    interface IMonster
    {
        abstract void Attack(Object source, System.Timers.ElapsedEventArgs e);
        abstract void Die();
        abstract void OnMonsterAttackTriggered(float damage);
    }
}
