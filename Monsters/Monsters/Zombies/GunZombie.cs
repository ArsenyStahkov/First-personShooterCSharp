using TheGame.Base.Interfaces;
using TheGame.Weapons;

namespace TheGame.Monsters.Zombies;

public sealed class GunZombie : Zombie, IMonster
{
    private const int _fixedDelay = 1200;
    private const string _zombieIsDead = "Zombie with Gun is dead";

    public GunZombie()
    {
        _zombieWeapon = new Gun() { IsInfiniteAmmo = true };
        _delayBeforeAttack = _fixedDelay + _zombieWeapon.FireRate;
    }

    public GunZombie(ushort health)
    {
        _health = health > 0 ? health : _fixedHealth;
        _zombieWeapon = new Gun() { IsInfiniteAmmo = true };
        _delayBeforeAttack = _fixedDelay + _zombieWeapon.FireRate;
    }

    public GunZombie(ushort health, float damage)
    {
        _health = health > 0 ? health : _fixedHealth;
        _zombieWeapon = new Gun(damage) { IsInfiniteAmmo = true };
        _delayBeforeAttack = _fixedDelay + _zombieWeapon.FireRate;
    }

    public override void Die()
    {
        _timer.Stop();
        _timer.Dispose();
        Console.WriteLine(_zombieIsDead);
    }
}
