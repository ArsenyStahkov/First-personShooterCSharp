namespace TheGame.Player;

interface IPlayer
{
    abstract short Health { get; set; }
    abstract short Armor { get; set; }
    abstract float Damage { get; set; }
    abstract void PressKey();
    abstract void Attack();
    abstract void Die();
}
