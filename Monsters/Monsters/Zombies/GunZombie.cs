using TheGame.Base.Interfaces;
using TheGame.Weapons;

namespace TheGame.Monsters.Zombies;

public sealed class GunZombie : Zombie, IMonster
{
    private const string _zombieIsDead = "Zombie with Gun is dead";

    public GunZombie()
    {
        _zombieWeapon = new Gun() { IsInfiniteAmmo = true };
        _delayBeforeAttack = 1200 + _zombieWeapon.FireRate;
    }

    public GunZombie(ushort health)
    {
        _health = health;
        _zombieWeapon = new Gun() { IsInfiniteAmmo = true };
        _delayBeforeAttack = 1200 + _zombieWeapon.FireRate;
    }

    public GunZombie(ushort health, ushort maxAmmo, float damage)
    {
        _health = health;
        _zombieWeapon = new Gun(maxAmmo, damage) { IsInfiniteAmmo = true };
        _delayBeforeAttack = 1200 + _zombieWeapon.FireRate;
    }

    public override void Die()
    {
        _timer.Stop();
        _timer.Dispose();
        Console.WriteLine(_zombieIsDead);
    }
}
