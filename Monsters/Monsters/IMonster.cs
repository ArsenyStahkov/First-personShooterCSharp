namespace TheGame.Monsters
{
    interface IMonster
    {
        abstract ushort Health { get; }
        abstract float Damage { get; set; }
        abstract void Attack(Object source, System.Timers.ElapsedEventArgs e);
        abstract void Die();
        abstract void OnMonsterAttackTriggered(float damage);
    }
}
